using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;

namespace SystemCri.Domain.Interfaces
{
    public interface ITipoCargoTrabajoRepository
    {
        Task<IEnumerable<TipoCargoTrabajo>> GetAllAsync();
        Task<TipoCargoTrabajo?> GetByIdAsync(int id);
        Task AddAsync(TipoCargoTrabajo entity);
        Task UpdateAsync(TipoCargoTrabajo entity);
        Task DeleteAsync(TipoCargoTrabajo entity);
        Task<bool> ExistsAsync(int id);
    }
}
