namespace CourseService.Models;

public class Course
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = "";
    public string Code { get; set; } = "";
    public string Description { get; set; } = "";
    public int TotalSeats { get; set; }
    public int ReservedSeats { get; set; }
    public decimal FeeAmount { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int AvailableSeats => TotalSeats - ReservedSeats;

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}

public class Enrollment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid EnrollmentId { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public int SeatNumber { get; set; }
    public EnrollmentStatus Status { get; set; } = EnrollmentStatus.SeatReserved;
    public DateTime ReservedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ReleasedAt { get; set; }

    public Course Course { get; set; } = null!;
}

public enum EnrollmentStatus
{
    SeatReserved,
    Confirmed,
    Released
}