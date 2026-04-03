using Microsoft.EntityFrameworkCore;
using StudentService.Models;

namespace StudentService.Data;

public class StudentDbContext : DbContext
{
    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<ValidationLog> ValidationLogs => Set<ValidationLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(s => s.Id);

            entity.Property(s => s.FullName)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(s => s.Email)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.HasIndex(s => s.Email).IsUnique();

            entity.Property(s => s.NationalId)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.HasIndex(s => s.NationalId).IsUnique();

            entity.Property(s => s.Status)
                  .HasConversion<string>();
        });

        modelBuilder.Entity<ValidationLog>(entity =>
        {
            entity.HasKey(v => v.Id);

            entity.HasOne(v => v.Student)
                  .WithMany()
                  .HasForeignKey(v => v.StudentId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
