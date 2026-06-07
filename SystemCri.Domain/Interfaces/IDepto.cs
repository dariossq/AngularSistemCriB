using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;

namespace SystemCri.Domain.Interfaces
{
    public interface IDeptoRepository
    {
        Task<IEnumerable<Depto>> GetAllAsync();
        Task<Depto?> GetByIdAsync(int id);
        Task AddAsync(Depto depto);
        Task UpdateAsync(Depto depto);
        Task DeleteAsync(Depto depto);
        Task<bool> ExistsAsync(int id);
    }
}
