using System;
using System.Collections.Generic;
using DBFirstCode.Models;
using Microsoft.EntityFrameworkCore;

namespace DBFirstCode.Data;

public partial class DbfirstCodeDatabaseContext : DbContext
{
    public DbfirstCodeDatabaseContext()
    {
    }

    public DbfirstCodeDatabaseContext(DbContextOptions<DbfirstCodeDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=DBFirstCodeDatabase;Persist Security Info=True;User ID=sa;Password=Deku@0604;Pooling=False;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED81D5E405");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11970875E1");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees).HasConstraintName("FK_Employee_Department");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
