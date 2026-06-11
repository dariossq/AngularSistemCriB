using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;
using SystemCri.Infrastructure.Data;

namespace SystemCri.Infrastructure.Repositories
{
    public class TipoIdRepository : ITipoIdRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoIdRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<TipoId>> GetAllAsync() => await _context.TipoIds.ToListAsync();

        public async Task<TipoId?> GetByIdAsync(int id) => await _context.TipoIds.FindAsync(id);

        public async Task AddAsync(TipoId entity)
        {
            await _context.TipoIds.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TipoId entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TipoId entity)
        {
            _context.TipoIds.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id) => await _context.TipoIds.AnyAsync(e => e.TipoIdCod == id);
    }
}
