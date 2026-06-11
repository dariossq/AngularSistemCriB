using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;

namespace SystemCri.Domain.Interfaces
{
    public interface IEscolaridadRepository
    {
        Task<IEnumerable<Escolaridad>> GetAllAsync();
        Task<Escolaridad?> GetByIdAsync(int id);
        Task AddAsync(Escolaridad entity);
        Task UpdateAsync(Escolaridad entity);
        Task DeleteAsync(Escolaridad entity);
        Task<bool> ExistsAsync(int id);
    }
}
