using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;
using SystemCri.Infrastructure.Data;

namespace SystemCri.Infrastructure.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly ApplicationDbContext _context;

        public RolRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Rol>> GetAllAsync() => await _context.Roles.ToListAsync();

        public async Task<Rol?> GetByIdAsync(int id) => await _context.Roles.FindAsync(id);

        public async Task AddAsync(Rol entity)
        {
            await _context.Roles.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Rol entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Rol entity)
        {
            _context.Roles.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id) => await _context.Roles.AnyAsync(e => e.RolCod == id);
    }
}
