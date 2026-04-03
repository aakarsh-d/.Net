using FeeService.Data;
using FeeService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FeeService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeesController : ControllerBase
{
    private readonly FeeDbContext _db;

    public FeesController(FeeDbContext db) => _db = db;

    /// <summary>Get fee record by enrollment saga ID.</summary>
    [HttpGet("enrollment/{enrollmentId:guid}")]
    public async Task<IActionResult> GetByEnrollment(Guid enrollmentId)
    {
        var fee = await _db.FeeRecords
            .FirstOrDefaultAsync(f => f.EnrollmentId == enrollmentId);

        if (fee is null) return NotFound(new { error = "No fee record found for this enrollment." });
        return Ok(ToDto(fee));
    }

    /// <summary>Get all fees for a student.</summary>
    [HttpGet("student/{studentId:guid}")]
    public async Task<IActionResult> GetByStudent(Guid studentId)
    {
        var fees = await _db.FeeRecords
            .Where(f => f.StudentId == studentId)
            .OrderByDescending(f => f.CreatedAt)
            .Select(f => ToDto(f))
            .ToListAsync();

        return Ok(fees);
    }

    /// <summary>Mark fee as paid.</summary>
    [HttpPatch("{feeRecordId:guid}/pay")]
    public async Task<IActionResult> MarkPaid(Guid feeRecordId)
    {
        var fee = await _db.FeeRecords.FindAsync(feeRecordId);
        if (fee is null) return NotFound();

        if (fee.Status == FeeStatus.Paid)
            return Conflict(new { error = "Fee is already marked as paid." });

        fee.Status = FeeStatus.Paid;
        fee.PaidAt = DateTime.UtcNow;
        await _db.SaveChangesAsync();

        return Ok(ToDto(fee));
    }

    private static FeeDto ToDto(FeeRecord f) => new(
        f.Id, f.EnrollmentId, f.StudentId, f.CourseId,
        f.CourseName, f.CourseCode, f.Amount,
        f.Status.ToString(), f.DueDate, f.CreatedAt, f.PaidAt);
}

public record FeeDto(
    Guid Id, Guid EnrollmentId, Guid StudentId, Guid CourseId,
    string CourseName, string CourseCode, decimal Amount,
    string Status, DateTime DueDate, DateTime CreatedAt, DateTime? PaidAt);
