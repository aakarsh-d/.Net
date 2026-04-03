using Microsoft.EntityFrameworkCore;
using OneToManyMVCDb.Models;
using System.Reflection.Emit;

namespace OneToManyMVCDb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API configuration for One-to-Many

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
