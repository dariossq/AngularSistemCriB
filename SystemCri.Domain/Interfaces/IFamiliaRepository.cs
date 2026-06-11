using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;

namespace SystemCri.Domain.Interfaces
{
    public interface IFamiliaRepository
    {
        Task<IEnumerable<Familia>> GetAllAsync();
        Task<Familia?> GetByIdAsync(int id);
        Task AddAsync(Familia entity);
        Task UpdateAsync(Familia entity);
        Task DeleteAsync(Familia entity);
        Task<bool> ExistsAsync(int id);
    }
}
