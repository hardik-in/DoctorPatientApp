using DoctorPatientApp.API.DTOs.Patient;

namespace DoctorPatientApp.API.Services.Interfaces
{
    public interface IPatientService
    {
        Task<PatientDto> GetPatientByIdAsync(int patientId);
        Task<PatientDto> GetPatientByUserIdAsync(int userId);
        Task<IEnumerable<PatientDto>> GetAllPatientsAsync();
        Task<PatientDto> CreatePatientAsync(CreatePatientDto createPatientDto);
        Task<PatientDto> UpdatePatientAsync(int patientId, UpdatePatientDto updatePatientDto);
        Task DeletePatientAsync(int patientId);
    }
}