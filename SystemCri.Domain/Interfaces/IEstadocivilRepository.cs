using SystemCri.Domain.Entities;

namespace SystemCri.Domain.Interfaces
{
    public interface IEstadocivilRepository
    {
        Task<IEnumerable<Estadocivil>> GetAllAsync();
        Task<Estadocivil?> GetByIdAsync(int id);
        Task AddAsync(Estadocivil entity);
        Task UpdateAsync(Estadocivil entity);
        Task DeleteAsync(Estadocivil entity);
        Task<bool> ExistsAsync(int id);
    }
}
