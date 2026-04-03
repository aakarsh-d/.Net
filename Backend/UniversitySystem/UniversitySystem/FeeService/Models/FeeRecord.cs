namespace FeeService.Models;

public class FeeRecord
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid EnrollmentId { get; set; }   // Saga correlation ID
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public string CourseName { get; set; } = "";
    public string CourseCode { get; set; } = "";
    public decimal Amount { get; set; }
    public FeeStatus Status { get; set; } = FeeStatus.Pending;
    public DateTime DueDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? PaidAt { get; set; }
}

public enum FeeStatus
{
    Pending,
    Paid,
    Cancelled,
    Overdue
}
