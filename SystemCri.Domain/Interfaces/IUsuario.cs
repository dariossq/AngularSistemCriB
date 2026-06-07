using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;

namespace SystemCri.Domain.Interfaces
{
   public interface IUsuarioRepository
   {
       Task<IEnumerable<Usuario>> GetAllAsync();
       Task<Usuario?> GetByIdAsync(int id);
       Task AddAsync(Usuario usuario);
       Task UpdateAsync(Usuario usuario);
       Task DeleteAsync(Usuario usuario);
       Task<bool> ExistsAsync(int id);
   }
}
