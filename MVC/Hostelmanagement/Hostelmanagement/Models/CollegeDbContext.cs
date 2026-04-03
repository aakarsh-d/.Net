using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hostelmanagement.Models;

public partial class CollegeDbContext : DbContext
{
    public CollegeDbContext()
    {
    }

    public CollegeDbContext(DbContextOptions<CollegeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hostel> Hostels { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=aakarsh\\SQLEXPRESS;Initial Catalog=CollegeDB;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hostel>(entity =>
        {
            entity.HasKey(e => e.HostelId).HasName("PK__Hostel__677EEB285EC8B145");

            entity.ToTable("Hostel");

            entity.Property(e => e.HostelName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B990D65B959");

            entity.ToTable("Student");

            entity.HasIndex(e => e.HostelId, "UQ__Student__677EEB29FE13F171").IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Hostel).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.HostelId)
                .HasConstraintName("FK__Student__HostelI__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
