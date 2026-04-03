using FeeService.Data;
using FeeService.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Events;

namespace FeeService.Consumers;

public class SeatReservedConsumer : IConsumer<SeatReserved>
{
    private readonly FeeDbContext _db;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<SeatReservedConsumer> _logger;

    public SeatReservedConsumer(
        FeeDbContext db,
        IPublishEndpoint publishEndpoint,
        ILogger<SeatReservedConsumer> logger)
    {
        _db = db;
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<SeatReserved> context)
    {
        var msg = context.Message;

        _logger.LogInformation(
            "SeatReserved received. EnrollmentId={EnrollmentId}, Course={CourseCode}",
            msg.EnrollmentId, msg.CourseCode);

        // Idempotency check — skip if fee already created
        var existing = await _db.FeeRecords
            .AnyAsync(f => f.EnrollmentId == msg.EnrollmentId);

        if (existing)
        {
            _logger.LogWarning(
                "FeeRecord already exists for EnrollmentId={EnrollmentId}. Skipping.",
                msg.EnrollmentId);
            return;
        }

        try
        {
            var feeAmount = Math.Round(msg.CourseFeeAmount * 1.05m, 2);
            var dueDate = DateTime.UtcNow.AddDays(30);

            var feeRecord = new FeeRecord
            {
                EnrollmentId = msg.EnrollmentId,
                StudentId = msg.StudentId,
                CourseId = msg.CourseId,
                CourseName = msg.CourseName,
                CourseCode = msg.CourseCode,
                Amount = feeAmount,
                DueDate = dueDate,
                Status = FeeStatus.Pending
            };

            _db.FeeRecords.Add(feeRecord);
            await _db.SaveChangesAsync();

            _logger.LogInformation(
                "FeeRecord {FeeRecordId} created. Amount={Amount}. Saga complete.",
                feeRecord.Id, feeAmount);

            await _publishEndpoint.Publish(new FeeCreated(
                EnrollmentId: msg.EnrollmentId,
                StudentId: msg.StudentId,
                CourseId: msg.CourseId,
                FeeRecordId: feeRecord.Id,
                Amount: feeAmount,
                DueDate: dueDate
            ));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "Failed to create fee. EnrollmentId={EnrollmentId}. Triggering compensation.",
                msg.EnrollmentId);

            await _publishEndpoint.Publish(new EnrollmentFailed(
                EnrollmentId: msg.EnrollmentId,
                StudentId: msg.StudentId,
                CourseId: msg.CourseId,
                Reason: $"Fee creation failed: {ex.Message}",
                FailedAt: DateTime.UtcNow
            ));
        }
    }
}