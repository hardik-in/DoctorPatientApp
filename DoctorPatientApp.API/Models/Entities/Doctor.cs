using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorPatientApp.API.Models.Entities
{
    public class Doctor : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        // Doctor can exist without assigned admin.
        public int? AssignedAdminId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Specialization { get; set; }

        [Required]
        [MaxLength(50)]
        public string LicenseNumber { get; set; }

        [Required]
        public int YearsOfExperience { get; set; }

        [MaxLength(200)]
        public string Qualifications { get; set; }

        [MaxLength(500)]
        public string Bio { get; set; }

        [Required]
        public decimal ConsultationFee { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        // Many Doctors can belong to one Admin
        [ForeignKey("AssignedAdminId")]
        public Admin? AssignedAdmin { get; set; }

        public ICollection<TimeSlot> TimeSlots { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}