using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;

namespace SystemCri.Domain.Interfaces
{
    public interface IRolRepository
    {
        Task<IEnumerable<Rol>> GetAllAsync();
        Task<Rol?> GetByIdAsync(int id);
        Task AddAsync(Rol entity);
        Task UpdateAsync(Rol entity);
        Task DeleteAsync(Rol entity);
        Task<bool> ExistsAsync(int id);
    }
}
