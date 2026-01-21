using DoctorPatientApp.API.Models;
using DoctorPatientApp.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorPatientApp.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets - Represent tables in database
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
            });

            // Configure Admin - User relationship (One-to-One)
            modelBuilder.Entity<Admin>()
                .HasOne(a => a.User)
                .WithOne(u => u.Admin)
                .HasForeignKey<Admin>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Doctor - User relationship (One-to-One)
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.User)
                .WithOne(u => u.Doctor)
                .HasForeignKey<Doctor>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Patient - User relationship (One-to-One)
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithOne(u => u.Patient)
                .HasForeignKey<Patient>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Admin - Doctor relationship (One-to-Many)
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.AssignedAdmin)
                .WithMany(a => a.ManagedDoctors)
                .HasForeignKey(d => d.AssignedAdminId)
                .OnDelete(DeleteBehavior.SetNull);

            // Configure Doctor - TimeSlot relationship (One-to-Many)
            modelBuilder.Entity<TimeSlot>()
                .HasOne(ts => ts.Doctor)
                .WithMany(d => d.TimeSlots)
                .HasForeignKey(ts => ts.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure TimeSlot - Appointment relationship (One-to-One)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.TimeSlot)
                .WithOne(ts => ts.Appointment)
                .HasForeignKey<Appointment>(a => a.TimeSlotId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Patient - Appointment relationship (One-to-Many)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Doctor - Appointment relationship (One-to-Many)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Appointment - MedicalRecord relationship (One-to-One)
            modelBuilder.Entity<MedicalRecord>()
                .HasOne(mr => mr.Appointment)
                .WithOne(a => a.MedicalRecord)
                .HasForeignKey<MedicalRecord>(mr => mr.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Patient - MedicalRecord relationship (One-to-Many)
            modelBuilder.Entity<MedicalRecord>()
                .HasOne(mr => mr.Patient)
                .WithMany(p => p.MedicalRecords)
                .HasForeignKey(mr => mr.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Doctor - MedicalRecord relationship (One-to-Many)
            modelBuilder.Entity<MedicalRecord>()
                .HasOne(mr => mr.Doctor)
                .WithMany(d => d.MedicalRecords)
                .HasForeignKey(mr => mr.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Appointment - Prescription relationship (One-to-Many)
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Appointment)
                .WithMany(a => a.Prescriptions)
                .HasForeignKey(p => p.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Patient - Prescription relationship (One-to-Many)
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Patient)
                .WithMany(pt => pt.Prescriptions)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Doctor - Prescription relationship (One-to-Many)
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Doctor)
                .WithMany(d => d.Prescriptions)
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure MedicalRecord - Prescription relationship (One-to-Many)
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.MedicalRecord)
                .WithMany(mr => mr.Prescriptions)
                .HasForeignKey(p => p.MedicalRecordId)
                .OnDelete(DeleteBehavior.SetNull);

            // Configure decimal precision for money fields
            modelBuilder.Entity<Doctor>()
                .Property(d => d.ConsultationFee)
                .HasPrecision(10, 2);

            modelBuilder.Entity<MedicalRecord>()
                .Property(mr => mr.Temperature)
                .HasPrecision(5, 2);

            modelBuilder.Entity<MedicalRecord>()
                .Property(mr => mr.Weight)
                .HasPrecision(5, 2);

            modelBuilder.Entity<MedicalRecord>()
                .Property(mr => mr.Height)
                .HasPrecision(5, 2);
        }
    }
}