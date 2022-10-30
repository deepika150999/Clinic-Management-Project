using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StoneClinicApi.Models
{
    public partial class StoneClinicContext : DbContext
    {
        public StoneClinicContext()
        {
        }

        public StoneClinicContext(DbContextOptions<StoneClinicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppointmentDetail> AppointmentDetails { get; set; } = null!;
        public virtual DbSet<DoctorDetail> DoctorDetails { get; set; } = null!;
        public virtual DbSet<PatientDetail> PatientDetails { get; set; } = null!;
        public virtual DbSet<Userpage> Userpages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GQJ9GIB;Database=StoneClinic;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentDetail>(entity =>
            {
                entity.HasKey(e => e.AppointmentNumber)
                    .HasName("PK__Appointm__23EF3BAE1AAD5F9F");

                entity.ToTable("AppointmentDetail");

                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.Property(e => e.AppointmentDuration)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Specialization)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.AppointmentDetails)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Appointme__Docto__31EC6D26");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.AppointmentDetails)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Appointme__Patie__30F848ED");
            });

            modelBuilder.Entity<DoctorDetail>(entity =>
            {
                entity.HasKey(e => e.DoctorId)
                    .HasName("PK__DoctorDe__2DC00EBFAFCBF98F");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Specialization)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VistingHours)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PatientDetail>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PK__PatientD__970EC366B32BB68B");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Userpage>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__Userpage__C9F28457E9CF240C");

                entity.ToTable("Userpage");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
