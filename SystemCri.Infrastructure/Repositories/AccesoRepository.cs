using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;
using SystemCri.Infrastructure.Data;

namespace SystemCri.Infrastructure.Repositories
{
    public class AccesoRepository : IAccesoRepository
    {
        private readonly ApplicationDbContext _context;

        public AccesoRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Acceso>> GetAllAsync() => await _context.Accesos.ToListAsync();

        public async Task<Acceso?> GetByIdAsync(int id) => await _context.Accesos.FindAsync(id);

        public async Task AddAsync(Acceso acceso)
        {
            await _context.Accesos.AddAsync(acceso);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Acceso acceso)
        {
            _context.Entry(acceso).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Acceso acceso)
        {
            _context.Accesos.Remove(acceso);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id) => await _context.Accesos.AnyAsync(e => e.CodAcceso == id);
    }
}
