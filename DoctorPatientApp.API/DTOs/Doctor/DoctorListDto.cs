namespace DoctorPatientApp.API.DTOs.Doctor
{
    public class DoctorListDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal ConsultationFee { get; set; }
        public bool IsActive { get; set; }
    }
}