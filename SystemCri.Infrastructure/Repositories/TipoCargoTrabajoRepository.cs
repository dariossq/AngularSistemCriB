using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;
using SystemCri.Infrastructure.Data;

namespace SystemCri.Infrastructure.Repositories
{
    public class TipoCargoTrabajoRepository : ITipoCargoTrabajoRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoCargoTrabajoRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<TipoCargoTrabajo>> GetAllAsync() => await _context.TipoCargoTrabajos.ToListAsync();

        public async Task<TipoCargoTrabajo?> GetByIdAsync(int id) => await _context.TipoCargoTrabajos.FindAsync(id);

        public async Task AddAsync(TipoCargoTrabajo entity)
        {
            await _context.TipoCargoTrabajos.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TipoCargoTrabajo entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TipoCargoTrabajo entity)
        {
            _context.TipoCargoTrabajos.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id) => await _context.TipoCargoTrabajos.AnyAsync(e => e.TicaCod == id);
    }
}
