using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;

namespace SystemCri.Domain.Interfaces
{
    public interface IGeneroRepository
    {
        Task<IEnumerable<Genero>> GetAllAsync();
        Task<Genero?> GetByIdAsync(int id);
        Task AddAsync(Genero entity);
        Task UpdateAsync(Genero entity);
        Task DeleteAsync(Genero entity);
        Task<bool> ExistsAsync(int id);
    }
}
