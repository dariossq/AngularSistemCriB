using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;

namespace SystemCri.Domain.Interfaces
{
    public interface ISeguridadRepository
    {
        Task<IEnumerable<Seguridad>> GetAllAsync();
        Task<Seguridad?> GetByIdAsync(int id);
        Task AddAsync(Seguridad seguridad);
        Task UpdateAsync(Seguridad seguridad);
        Task DeleteAsync(Seguridad seguridad);
        Task<bool> ExistsAsync(int id);
    }
}
