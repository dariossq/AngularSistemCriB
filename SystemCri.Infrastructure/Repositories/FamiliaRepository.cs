using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;
using SystemCri.Infrastructure.Data;

namespace SystemCri.Infrastructure.Repositories
{
    public class FamiliaRepository : IFamiliaRepository
    {
        private readonly ApplicationDbContext _context;

        public FamiliaRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Familia>> GetAllAsync() => await _context.Familias.ToListAsync();

        public async Task<Familia?> GetByIdAsync(int id) => await _context.Familias.FindAsync(id);

        public async Task AddAsync(Familia entity)
        {
            await _context.Familias.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Familia entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Familia entity)
        {
            _context.Familias.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id) => await _context.Familias.AnyAsync(e => e.FamCod == id);
    }
}
