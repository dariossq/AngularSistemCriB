using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;
using SystemCri.Infrastructure.Data;

namespace SystemCri.Infrastructure.Repositories
{
    public class VeredaRepository : IVeredaRepository
    {
        private readonly ApplicationDbContext _context;

        public VeredaRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Vereda>> GetAllAsync() => await _context.Veredas.ToListAsync();

        public async Task<Vereda?> GetByIdAsync(int id) => await _context.Veredas.FindAsync(id);

        public async Task AddAsync(Vereda vereda)
        {
            await _context.Veredas.AddAsync(vereda);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vereda vereda)
        {
            _context.Entry(vereda).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Vereda vereda)
        {
            _context.Veredas.Remove(vereda);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id) => await _context.Veredas.AnyAsync(e => e.VeredaCod == id);
    }
}
