using MassTransit;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Events;
using StudentService.Data;
using StudentService.Models;

namespace StudentService.Consumers;

// ─── Handles compensation when seat reservation fails ────────────────────────
public class SeatReservationFailedConsumer : IConsumer<SeatReservationFailed>
{
    private readonly StudentDbContext _db;
    private readonly ILogger<SeatReservationFailedConsumer> _logger;
    private readonly IPublishEndpoint _publishEndpoint;

    public SeatReservationFailedConsumer(
        StudentDbContext db,
        ILogger<SeatReservationFailedConsumer> logger,
        IPublishEndpoint publishEndpoint)
    {
        _db = db;
        _logger = logger;
        _publishEndpoint = publishEndpoint;
    }

    public async Task Consume(ConsumeContext<SeatReservationFailed> context)
    {
        var msg = context.Message;
        _logger.LogWarning(
            "Seat reservation failed for EnrollmentId={EnrollmentId}, StudentId={StudentId}. Reason: {Reason}",
            msg.EnrollmentId, msg.StudentId, msg.Reason);

        var student = await _db.Students.FirstOrDefaultAsync(s => s.Id == msg.StudentId);

        if (student is null)
        {
            _logger.LogError("Compensation failed — student {StudentId} not found.", msg.StudentId);
            return;
        }

        // Compensating transaction: mark student as failed
        student.Status = EnrollmentStatus.Failed;
        student.UpdatedAt = DateTime.UtcNow;
        await _db.SaveChangesAsync();

        // Publish cancellation event (for audit/notification)
        await _publishEndpoint.Publish(new StudentEnrollmentCancelled(
            EnrollmentId: msg.EnrollmentId,
            StudentId: msg.StudentId,
            Reason: $"Seat reservation failed: {msg.Reason}"
        ));

        _logger.LogInformation(
            "Compensation complete — student {StudentId} marked as Failed.", msg.StudentId);
    }
}

// ─── Handles compensation when fee creation fails ────────────────────────────
public class EnrollmentFailedConsumer : IConsumer<EnrollmentFailed>
{
    private readonly StudentDbContext _db;
    private readonly ILogger<EnrollmentFailedConsumer> _logger;
    private readonly IPublishEndpoint _publishEndpoint;

    public EnrollmentFailedConsumer(
        StudentDbContext db,
        ILogger<EnrollmentFailedConsumer> logger,
        IPublishEndpoint publishEndpoint)
    {
        _db = db;
        _logger = logger;
        _publishEndpoint = publishEndpoint;
    }

    public async Task Consume(ConsumeContext<EnrollmentFailed> context)
    {
        var msg = context.Message;
        _logger.LogWarning(
            "Enrollment failed — compensating student. EnrollmentId={EnrollmentId}, Reason={Reason}",
            msg.EnrollmentId, msg.Reason);

        var student = await _db.Students.FirstOrDefaultAsync(s => s.Id == msg.StudentId);

        if (student is null)
        {
            _logger.LogError("Compensation: student {StudentId} not found.", msg.StudentId);
            return;
        }

        student.Status = EnrollmentStatus.Failed;
        student.UpdatedAt = DateTime.UtcNow;
        await _db.SaveChangesAsync();

        await _publishEndpoint.Publish(new StudentEnrollmentCancelled(
            EnrollmentId: msg.EnrollmentId,
            StudentId: msg.StudentId,
            Reason: $"Enrollment failed at fee stage: {msg.Reason}"
        ));

        _logger.LogInformation("Student {StudentId} compensated — marked as Failed.", msg.StudentId);
    }
}
