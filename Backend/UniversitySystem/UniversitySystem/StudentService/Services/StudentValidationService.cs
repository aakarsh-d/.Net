using StudentService.Data;
using StudentService.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentService.Services;

public interface IStudentValidationService
{
    Task<ValidationResult> ValidateAsync(StudentValidationRequest request);
}

public record StudentValidationRequest(
    string FullName,
    string Email,
    string NationalId,
    DateTime DateOfBirth,
    Guid CourseId
);

public record ValidationResult(bool IsValid, string Message);

public class StudentValidationService : IStudentValidationService
{
    private readonly StudentDbContext _db;

    public StudentValidationService(StudentDbContext db)
    {
        _db = db;
    }

    public async Task<ValidationResult> ValidateAsync(StudentValidationRequest request)
    {
        // Rule 1: Minimum age 17
        var age = DateTime.UtcNow.Year - request.DateOfBirth.Year;
        if (age < 17)
            return new ValidationResult(false, "Student must be at least 17 years old.");

        // Rule 2: Email must not already be enrolled
        var emailExists = await _db.Students
            .AnyAsync(s => s.Email == request.Email && s.Status == EnrollmentStatus.Active);

        if (emailExists)
            return new ValidationResult(false, $"A student with email '{request.Email}' is already actively enrolled.");

        // Rule 3: NationalId must be unique across the system
        var nationalIdExists = await _db.Students
            .AnyAsync(s => s.NationalId == request.NationalId);

        if (nationalIdExists)
            return new ValidationResult(false, $"National ID '{request.NationalId}' is already registered.");

        // Rule 4: Name must not be empty or whitespace only
        if (string.IsNullOrWhiteSpace(request.FullName) || request.FullName.Trim().Length < 3)
            return new ValidationResult(false, "Full name must be at least 3 characters.");

        // Rule 5: Course ID must be provided
        if (request.CourseId == Guid.Empty)
            return new ValidationResult(false, "A valid course must be selected.");

        return new ValidationResult(true, "Validation passed.");
    }
}
