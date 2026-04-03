using CourseService.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseService.Data;

public class CourseDbContext : DbContext
{
    public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options) { }

    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Name).IsRequired().HasMaxLength(300);
            entity.Property(c => c.Code).IsRequired().HasMaxLength(20);
            entity.HasIndex(c => c.Code).IsUnique();

            entity.Property(c => c.FeeAmount).HasColumnType("decimal(10,2)");

            // Ignore computed property — not stored in DB
            entity.Ignore(c => c.AvailableSeats);
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.EnrollmentId).IsUnique(); // one saga = one enrollment
            entity.HasIndex(e => new { e.StudentId, e.CourseId });

            entity.Property(e => e.Status).HasConversion<string>();

            entity.HasOne(e => e.Course)
                  .WithMany(c => c.Enrollments)
                  .HasForeignKey(e => e.CourseId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Seed data — 3 sample courses
        modelBuilder.Entity<Course>().HasData(
            new Course
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "Computer Science",
                Code = "CS101",
                Description = "Introduction to Computer Science",
                TotalSeats = 60,
                ReservedSeats = 0,
                FeeAmount = 15000m,
                CreatedAt = DateTime.UtcNow
            },
            new Course
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Name = "Business Administration",
                Code = "BA101",
                Description = "Foundation of Business",
                TotalSeats = 80,
                ReservedSeats = 0,
                FeeAmount = 12000m,
                CreatedAt = DateTime.UtcNow
            },
            new Course
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Name = "Electrical Engineering",
                Code = "EE101",
                Description = "Core Electrical Engineering",
                TotalSeats = 40,
                ReservedSeats = 0,
                FeeAmount = 18000m,
                CreatedAt = DateTime.UtcNow
            }
        );
    }
}
