using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace medicalproject.Models;

public partial class MedicaldbContext : DbContext
{
    public MedicaldbContext()
    {
    }

    public MedicaldbContext(DbContextOptions<MedicaldbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DoctorTable> DoctorTables { get; set; }

    public virtual DbSet<Parma> Parmas { get; set; }

    public virtual DbSet<PatientTable> PatientTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SPOTHALA-L-5519;Initial Catalog=medicaldb;Persist Security Info=True;User ID=sa;Password=Support@123456; Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DoctorTable>(entity =>
        {
            entity.HasKey(e => e.DoctorType);

            entity.ToTable("Doctor_table");

            entity.Property(e => e.DoctorType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Doctor_type");
            entity.Property(e => e.TypeOfMedicines)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("type_of_medicines");
        });

        modelBuilder.Entity<Parma>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("parma");

            entity.Property(e => e.Agegroup)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Appointment).WithMany()
                .HasForeignKey(d => d.AppointmentId)
                .HasConstraintName("FK_parma_patient_table");
        });

        modelBuilder.Entity<PatientTable>(entity =>
        {
            entity.ToTable("patient_table");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.DoctorType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("doctor_type");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNo).HasColumnName("phone_no");

            entity.HasOne(d => d.DoctorTypeNavigation).WithMany(p => p.PatientTables)
                .HasForeignKey(d => d.DoctorType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_patient_table_Doctor_table");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
