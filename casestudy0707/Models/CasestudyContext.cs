using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace casestudy0707.Models;

public partial class CasestudyContext : DbContext
{
    public CasestudyContext()
    {
    }

    public CasestudyContext(DbContextOptions<CasestudyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentDb> StudentDbs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SPOTHALA-L-5519;Initial Catalog=casestudy;User ID=sa;Password=Support@123456; Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentDb>(entity =>
        {
            entity.HasKey(e => e.Rno);

            entity.ToTable("StudentDb");

            entity.Property(e => e.Rno)
                .ValueGeneratedNever()
                .HasColumnName("RNo");
            entity.Property(e => e.Grade)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MathsMark)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Maths_mark");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ScienceMark)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Science_mark");
            entity.Property(e => e.Section)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Total)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
