using CourseService.Data;
using CourseService.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Events;

namespace CourseService.Consumers;

public class StudentCreatedConsumer : IConsumer<StudentCreated>
{
    private readonly CourseDbContext _db;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<StudentCreatedConsumer> _logger;

    public StudentCreatedConsumer(
        CourseDbContext db,
        IPublishEndpoint publishEndpoint,
        ILogger<StudentCreatedConsumer> logger)
    {
        _db = db;
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<StudentCreated> context)
    {
        var msg = context.Message;

        _logger.LogInformation(
            "StudentCreated received. EnrollmentId={EnrollmentId}, CourseId={CourseId}",
            msg.EnrollmentId, msg.CourseId);

        var course = await _db.Courses
            .FirstOrDefaultAsync(c => c.Id == msg.CourseId);

        if (course is null)
        {
            await _publishEndpoint.Publish(new SeatReservationFailed(
                EnrollmentId: msg.EnrollmentId,
                StudentId: msg.StudentId,
                CourseId: msg.CourseId,
                Reason: $"Course {msg.CourseId} does not exist."
            ));
            return;
        }

        if (!course.IsActive)
        {
            await _publishEndpoint.Publish(new SeatReservationFailed(
                EnrollmentId: msg.EnrollmentId,
                StudentId: msg.StudentId,
                CourseId: msg.CourseId,
                Reason: $"Course '{course.Name}' is no longer active."
            ));
            return;
        }

        if (course.AvailableSeats <= 0)
        {
            await _publishEndpoint.Publish(new SeatReservationFailed(
                EnrollmentId: msg.EnrollmentId,
                StudentId: msg.StudentId,
                CourseId: msg.CourseId,
                Reason: $"No seats available in '{course.Name}'."
            ));
            return;
        }

        course.ReservedSeats++;
        var seatNumber = course.ReservedSeats;

        var enrollment = new Enrollment
        {
            EnrollmentId = msg.EnrollmentId,
            StudentId = msg.StudentId,
            CourseId = course.Id,
            SeatNumber = seatNumber,
            Status = EnrollmentStatus.SeatReserved
        };

        _db.Enrollments.Add(enrollment);
        await _db.SaveChangesAsync();

        _logger.LogInformation(
            "Seat {SeatNumber} reserved. Publishing SeatReserved.", seatNumber);

        await _publishEndpoint.Publish(new SeatReserved(
            EnrollmentId: msg.EnrollmentId,
            StudentId: msg.StudentId,
            CourseId: course.Id,
            CourseName: course.Name,
            CourseCode: course.Code,
            CourseFeeAmount: course.FeeAmount,
            SeatNumber: seatNumber
        ));
    }
}

public class EnrollmentFailedConsumer : IConsumer<EnrollmentFailed>
{
    private readonly CourseDbContext _db;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<EnrollmentFailedConsumer> _logger;

    public EnrollmentFailedConsumer(
        CourseDbContext db,
        IPublishEndpoint publishEndpoint,
        ILogger<EnrollmentFailedConsumer> logger)
    {
        _db = db;
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<EnrollmentFailed> context)
    {
        var msg = context.Message;

        _logger.LogWarning(
            "EnrollmentFailed — releasing seat. EnrollmentId={EnrollmentId}",
            msg.EnrollmentId);

        var enrollment = await _db.Enrollments
            .Include(e => e.Course)
            .FirstOrDefaultAsync(e => e.EnrollmentId == msg.EnrollmentId);

        if (enrollment is null)
        {
            _logger.LogWarning(
                "No enrollment found for EnrollmentId={EnrollmentId}. Nothing to release.",
                msg.EnrollmentId);
            return;
        }

        enrollment.Course.ReservedSeats = Math.Max(0, enrollment.Course.ReservedSeats - 1);
        enrollment.Status = EnrollmentStatus.Released;
        enrollment.ReleasedAt = DateTime.UtcNow;
        await _db.SaveChangesAsync();

        await _publishEndpoint.Publish(new SeatReleased(
            EnrollmentId: msg.EnrollmentId,
            CourseId: enrollment.CourseId,
            SeatNumber: enrollment.SeatNumber,
            Reason: msg.Reason
        ));

        _logger.LogInformation(
            "Seat {SeatNumber} released. Compensation complete.", enrollment.SeatNumber);
    }
}