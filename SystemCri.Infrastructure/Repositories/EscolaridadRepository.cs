using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;
using SystemCri.Infrastructure.Data;

namespace SystemCri.Infrastructure.Repositories
{
    public class EscolaridadRepository : IEscolaridadRepository
    {
        private readonly ApplicationDbContext _context;

        public EscolaridadRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Escolaridad>> GetAllAsync() => await _context.Escolaridads.ToListAsync();

        public async Task<Escolaridad?> GetByIdAsync(int id) => await _context.Escolaridads.FindAsync(id);

        public async Task AddAsync(Escolaridad entity)
        {
            await _context.Escolaridads.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Escolaridad entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Escolaridad entity)
        {
            _context.Escolaridads.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id) => await _context.Escolaridads.AnyAsync(e => e.EscolaridadCod == id);
    }
}
