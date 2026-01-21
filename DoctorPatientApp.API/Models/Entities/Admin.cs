using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorPatientApp.API.Models.Entities
{
    public class Admin : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Department { get; set; }

        [MaxLength(50)]
        public string EmployeeId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        // One Admin can manage multiple doctors.
        public ICollection<Doctor> ManagedDoctors { get; set; }
    }
}