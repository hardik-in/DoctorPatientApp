using DoctorPatientApp.API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorPatientApp.API.Models.Entities
{
    public class Patient : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        public BloodGroup? BloodGroup { get; set; }

        [MaxLength(1000)]
        public string Allergies { get; set; } = string.Empty;  // ← Default empty string

        [MaxLength(1000)]
        public string MedicalHistory { get; set; } = string.Empty;  // ← Default empty string

        [MaxLength(200)]
        public string EmergencyContactName { get; set; } = string.Empty;  // ← Default empty string

        [MaxLength(15)]
        public string EmergencyContactPhone { get; set; } = string.Empty;  // ← Default empty string

        // Navigation properties
        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}