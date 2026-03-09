//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using Paging.Models;

//namespace Paging.Data;

//public partial class ShkhaDbContext : DbContext
//{
//    public ShkhaDbContext()
//    {
//    }

//    public ShkhaDbContext(DbContextOptions<ShkhaDbContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<Record> Records { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=aakarsh\\SQLEXPRESS;Initial Catalog=shkhaDB;Integrated Security=True;TrustServerCertificate=True;");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Record>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Records__3214EC0759520D21");

//            entity.Property(e => e.Name)
//                .HasMaxLength(100)
//                .IsUnicode(false);
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}


using Microsoft.EntityFrameworkCore;
using Paging.Models;

namespace Paging.Data;

public partial class ShkhaDbContext : DbContext
{
    public ShkhaDbContext(DbContextOptions<ShkhaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Record> Records { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Record>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });
    }
}\