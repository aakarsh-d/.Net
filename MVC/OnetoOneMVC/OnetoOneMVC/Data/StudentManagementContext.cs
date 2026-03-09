using Microsoft.EntityFrameworkCore;
using OnetoOneMVC.Models;

namespace OnetoOneMVC.Data
{
    public class StudentManagementContext : DbContext
    {
        public StudentManagementContext(DbContextOptions<StudentManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Hostel> HostelRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.AssignedRoom)
                .WithOne(r => r.ResidentStudent)
                .HasForeignKey<Hostel>(r => r.StudentId);

            modelBuilder.Entity<Hostel>()
                .HasIndex(r => r.StudentId)
                .IsUnique();   // one room per student
        }
    }
}
