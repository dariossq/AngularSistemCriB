using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;

namespace SystemCri.Domain.Interfaces
{
    public interface ITipoIdRepository
    {
        Task<IEnumerable<TipoId>> GetAllAsync();
        Task<TipoId?> GetByIdAsync(int id);
        Task AddAsync(TipoId entity);
        Task UpdateAsync(TipoId entity);
        Task DeleteAsync(TipoId entity);
        Task<bool> ExistsAsync(int id);
    }
}
