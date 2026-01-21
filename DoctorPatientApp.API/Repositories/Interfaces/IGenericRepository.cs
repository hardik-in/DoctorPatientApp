using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace DoctorPatientApp.API.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        // Get all entities
        Task<IEnumerable<T>> GetAllAsync();

        // Get entity by ID
        Task<T> GetByIdAsync(int id);

        // Find entities matching a condition
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        // Get first entity matching a condition
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        // Add a new entity
        Task<T> AddAsync(T entity);

        // Add multiple entities
        Task AddRangeAsync(IEnumerable<T> entities);

        // Update an entity
        Task UpdateAsync(T entity);

        // Update multiple entities
        Task UpdateRangeAsync(IEnumerable<T> entities);

        // Delete an entity
        Task DeleteAsync(T entity);

        // Delete entity by ID
        Task DeleteByIdAsync(int id);

        // Soft delete (set IsDeleted = true)
        Task SoftDeleteAsync(T entity);

        // Check if entity exists
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

        // Count entities
        Task<int> CountAsync();

        // Count entities matching condition
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        // Save changes to database
        Task<int> SaveChangesAsync();

        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}