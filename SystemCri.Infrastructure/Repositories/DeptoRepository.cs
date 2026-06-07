using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;
using SystemCri.Infrastructure.Data;

namespace SystemCri.Infrastructure.Repositories
{
    public class DeptoRepository : IDeptoRepository
    {
        private readonly ApplicationDbContext _context;

        public DeptoRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Depto>> GetAllAsync() => await _context.Deptos.ToListAsync();

        public async Task<Depto?> GetByIdAsync(int id) => await _context.Deptos.FindAsync(id);

        public async Task AddAsync(Depto depto)
        {
            await _context.Deptos.AddAsync(depto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Depto depto)
        {
            _context.Entry(depto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Depto depto)
        {
            _context.Deptos.Remove(depto);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id) => await _context.Deptos.AnyAsync(e => e.DeptoCod == id);
    }
}
