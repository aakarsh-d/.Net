using FeeService.Data;
using FeeService.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Events;

namespace FeeService.Consumers;

// ─── Saga Step 3 (Final): Receives SeatReserved → creates fee record ──────────
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
            "SeatReserved received. EnrollmentId={EnrollmentId}, Course={CourseCode}, Fee={FeeAmount}",
            msg.EnrollmentId, msg.CourseCode, msg.CourseFeeAmount);

        // Idempotency check: if fee already created for this enrollment, skip
        var existing = await _db.FeeRecords
            .AnyAsync(f => f.EnrollmentId == msg.EnrollmentId);

        if (existing)
        {
            _logger.LogWarning(
                "FeeRecord already exists for EnrollmentId={EnrollmentId}. Skipping (idempotent).",
                msg.EnrollmentId);
            return;
        }

        try
        {
            // Calculate fee (could apply discounts, scholarships, etc. here)
            var feeAmount = CalculateFee(msg.CourseFeeAmount);
            var dueDate = DateTime.UtcNow.AddDays(30);

            // Local transaction: create fee record
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
                "FeeRecord {FeeRecordId} created. Amount={Amount}, Due={DueDate}. Saga complete.",
                feeRecord.Id, feeAmount, dueDate);

            // Publish final success event — saga is complete
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
                "Failed to create fee record for EnrollmentId={EnrollmentId}. Triggering compensation.",
                msg.EnrollmentId);

            // Publish failure — triggers compensation in Course Service and Student Service
            await _publishEndpoint.Publish(new EnrollmentFailed(
                EnrollmentId: msg.EnrollmentId,
                StudentId: msg.StudentId,
                CourseId: msg.CourseId,
                Reason: $"Fee creation failed: {ex.Message}",
                FailedAt: DateTime.UtcNow
            ));
        }
    }

    private static decimal CalculateFee(decimal baseFee)
    {
        // Apply a standard 5% processing charge
        // You could add scholarship deductions, instalment splits, etc. here
        return Math.Round(baseFee * 1.05m, 2);
    }
}
