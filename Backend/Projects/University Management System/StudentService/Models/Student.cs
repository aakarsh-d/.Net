using StudentService.Models;

namespace StudentService.Models
{
    public class Student
    {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FullName { get; set; } = "";
    public string Email { get; set; } = "";
    public string NationalId { get; set; } = "";
    public DateTime DateOfBirth { get; set; }
    public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Pending;
    public Guid? EnrolledCourseId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}

public enum EnrollmentStatus
{
    Pending,
    EnrollmentRequested,
    Active,
    Failed,
    Cancelled
}

public class ValidationLog
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid StudentId { get; set; }
    public bool IsValid { get; set; }
    public string Message { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Student Student { get; set; } = null!;
    }
}
