using DoctorPatientApp.API.Models.Entities;

namespace DoctorPatientApp.API.Repositories.Interfaces
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        Task<Admin> GetByUserIdAsync(int userId);
        Task<Admin> GetAdminWithUserAsync(int adminId);
        Task<Admin> GetAdminWithManagedDoctorsAsync(int adminId);
    }
}