using MassTransit;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Events;
using CourseService.Data;
using CourseService.Models;

namespace CourseService.Consumers;

// ─── Saga Step 2: Receives StudentCreated → reserves a seat ──────────────────
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

        // Load course with row-level lock to avoid race conditions
        var course = await _db.Courses
            .FirstOrDefaultAsync(c => c.Id == msg.CourseId);

        if (course is null)
        {
            _logger.LogError("Course {CourseId} not found.", msg.CourseId);

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
            _logger.LogWarning("No seats available in course {CourseCode}.", course.Code);

            await _publishEndpoint.Publish(new SeatReservationFailed(
                EnrollmentId: msg.EnrollmentId,
                StudentId: msg.StudentId,
                CourseId: msg.CourseId,
                Reason: $"No seats available in '{course.Name}'."
            ));
            return;
        }

        // Reserve the seat (local transaction)
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
            "Seat {SeatNumber} reserved in course {CourseCode}. Publishing SeatReserved.",
            seatNumber, course.Code);

        // Publish to trigger Fee Service (saga step 3)
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

// ─── Compensation: Release reserved seat when EnrollmentFailed ────────────────
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
            "EnrollmentFailed received — releasing seat. EnrollmentId={EnrollmentId}",
            msg.EnrollmentId);

        var enrollment = await _db.Enrollments
            .Include(e => e.Course)
            .FirstOrDefaultAsync(e => e.EnrollmentId == msg.EnrollmentId);

        if (enrollment is null)
        {
            _logger.LogWarning(
                "Compensation: no enrollment found for EnrollmentId={EnrollmentId}. Nothing to release.",
                msg.EnrollmentId);
            return;
        }

        // Compensating transaction: release the seat
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
            "Seat {SeatNumber} released in course {CourseId}. Compensation complete.",
            enrollment.SeatNumber, enrollment.CourseId);
    }
}
