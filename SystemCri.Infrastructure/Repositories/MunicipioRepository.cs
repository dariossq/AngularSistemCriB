//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SystemCri.Domain.Entities;
//using SystemCri.Domain.Interfaces;
//using SystemCri.Infrastructure.Data;

//namespace SystemCri.Infrastructure.Repositories
//{
//    public class MunicipioRepository : IMunicipioRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public MunicipioRepository(ApplicationDbContext context) => _context = context;

//        public async Task<IEnumerable<Municipio>> GetAllAsync() => await _context.Municipios.ToListAsync();

//        public async Task<Municipio?> GetByIdAsync(int id) => await _context.Municipios.FindAsync(id);

//        public async Task AddAsync(Municipio municipio)
//        {
//            await _context.Municipios.AddAsync(municipio);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateAsync(Municipio municipio)
//        {
//            _context.Entry(municipio).State = EntityState.Modified;
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(Municipio municipio)
//        {
//            _context.Municipios.Remove(municipio);
//            await _context.SaveChangesAsync();
//        }

//        public async Task<bool> ExistsAsync(int id) => await _context.Municipios.AnyAsync(e => e.MunicipioCod == id);
//    }
//}
