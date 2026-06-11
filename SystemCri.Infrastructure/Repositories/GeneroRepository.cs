using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;
using SystemCri.Infrastructure.Data;

namespace SystemCri.Infrastructure.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly ApplicationDbContext _context;

        public GeneroRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Genero>> GetAllAsync() => await _context.Generos.ToListAsync();

        public async Task<Genero?> GetByIdAsync(int id) => await _context.Generos.FindAsync(id);

        public async Task AddAsync(Genero entity)
        {
            await _context.Generos.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Genero entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Genero entity)
        {
            _context.Generos.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id) => await _context.Generos.AnyAsync(e => e.GeneroCod == id);
    }
}
