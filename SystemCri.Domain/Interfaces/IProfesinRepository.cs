using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;

namespace SystemCri.Domain.Interfaces
{
    public interface IProfesinRepository
    {
        Task<IEnumerable<Profesion>> GetAllAsync();
        Task<Profesion?> GetByIdAsync(int id);
        Task AddAsync(Profesion entity);
        Task UpdateAsync(Profesion entity);
        Task DeleteAsync(Profesion entity);
        Task<bool> ExistsAsync(int id);
    }
}
