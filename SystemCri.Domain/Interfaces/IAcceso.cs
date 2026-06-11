using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;

namespace SystemCri.Domain.Interfaces
{
    public interface IAccesoRepository
    {
        Task<IEnumerable<Acceso>> GetAllAsync();
        Task<Acceso?> GetByIdAsync(int id);
        Task AddAsync(Acceso acceso);
        Task UpdateAsync(Acceso acceso);
        Task DeleteAsync(Acceso acceso);
        Task<bool> ExistsAsync(int id);
    }
}
