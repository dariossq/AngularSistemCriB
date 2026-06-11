using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;
using SystemCri.Infrastructure.Data;

namespace SystemCri.Infrastructure.Repositories
{
    public class SeguridadRepository : ISeguridadRepository
    {
        private readonly ApplicationDbContext _context;

        public SeguridadRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Seguridad>> GetAllAsync() => await _context.Seguridads.ToListAsync();

        public async Task<Seguridad?> GetByIdAsync(int id) => await _context.Seguridads.FindAsync(id);

        public async Task AddAsync(Seguridad seguridad)
        {
            await _context.Seguridads.AddAsync(seguridad);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seguridad seguridad)
        {
            _context.Entry(seguridad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Seguridad seguridad)
        {
            _context.Seguridads.Remove(seguridad);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id) => await _context.Seguridads.AnyAsync(e => e.PerCod == id);
    }
}
