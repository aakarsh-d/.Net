using EFCodeFirstMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCodefirstMVC.Data
{
    public class StudentManagementContext : DbContext
    {
        public StudentManagementContext(DbContextOptions<StudentManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Bachhe { get; set; }
        //public DbSet<Hostel> Hostels { get; set; }


    }
}