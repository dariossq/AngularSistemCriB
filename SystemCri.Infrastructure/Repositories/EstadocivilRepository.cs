using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;
using SystemCri.Infrastructure.Data;

namespace SystemCri.Infrastructure.Repositories
{
    public class EstadocivilRepository : IEstadocivilRepository
    {
        private readonly ApplicationDbContext _context;

        public EstadocivilRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Estadocivil>> GetAllAsync() => await _context.Estadocivils.ToListAsync();

        public async Task<Estadocivil?> GetByIdAsync(int id) => await _context.Estadocivils.FindAsync(id);

        public async Task AddAsync(Estadocivil entity)
        {
            await _context.Estadocivils.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Estadocivil entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Estadocivil entity)
        {
            _context.Estadocivils.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id) => await _context.Estadocivils.AnyAsync(e => e.EstadocCod == id);
    }
}
