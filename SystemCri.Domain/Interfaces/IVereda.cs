using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;

namespace SystemCri.Domain.Interfaces
{
    public interface IVeredaRepository
    {
        Task<IEnumerable<Vereda>> GetAllAsync();
        Task<Vereda?> GetByIdAsync(int id);
        Task AddAsync(Vereda vereda);
        Task UpdateAsync(Vereda vereda);
        Task DeleteAsync(Vereda vereda);
        Task<bool> ExistsAsync(int id);
    }
}
