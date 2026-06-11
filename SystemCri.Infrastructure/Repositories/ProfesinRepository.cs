using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;
using SystemCri.Infrastructure.Data;

namespace SystemCri.Infrastructure.Repositories
{
    public class ProfesinRepository : IProfesinRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfesinRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Profesion>> GetAllAsync() => await _context.Profesions.ToListAsync();

        public async Task<Profesion?> GetByIdAsync(int id) => await _context.Profesions.FindAsync(id);

        public async Task AddAsync(Profesion entity)
        {
            await _context.Profesions.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Profesion entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Profesion entity)
        {
            _context.Profesions.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id) => await _context.Profesions.AnyAsync(e => e.ProfCod == id);
    }
}
