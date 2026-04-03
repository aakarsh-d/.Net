using FeeService.Models;
using Microsoft.EntityFrameworkCore;

namespace FeeService.Data;

public class FeeDbContext : DbContext
{
    public FeeDbContext(DbContextOptions<FeeDbContext> options) : base(options) { }

    public DbSet<FeeRecord> FeeRecords => Set<FeeRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FeeRecord>(entity =>
        {
            entity.HasKey(f => f.Id);

            entity.HasIndex(f => f.EnrollmentId).IsUnique(); // idempotency: one fee per saga
            entity.HasIndex(f => f.StudentId);

            entity.Property(f => f.Amount).HasColumnType("decimal(10,2)");
            entity.Property(f => f.Status).HasConversion<string>();

            entity.Property(f => f.CourseName).IsRequired().HasMaxLength(300);
            entity.Property(f => f.CourseCode).IsRequired().HasMaxLength(20);
        });
    }
}
