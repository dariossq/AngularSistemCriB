using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;

namespace SystemCri.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

       /// <summary>
        /// Obtiene o establece el conjunto de entidades Usuario.
        /// </summary>
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Depto> Deptos => Set<Depto>();
        public DbSet<Municipio> Municipios => Set<Municipio>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración explícita de la relación Municipio -> Depto
            modelBuilder.Entity<Municipio>()
                .HasOne(m => m.Depto)
                .WithMany() // Si quieres navegación inversa en Depto, añade ICollection<Municipio> en Depto y cámbialo a .WithMany(d => d.Municipios)
                .HasForeignKey(m => m.DeptoCod)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            // Configuración explícita de la relación Usuario -> Depto
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Departamento)
                .WithMany()
                .HasForeignKey(u => u.UsuarioDepartamento)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            // Configuración explícita de la relación Usuario -> Municipio
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Municipio)
                .WithMany()
                .HasForeignKey(u => u.UsuarioMunicipio)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
        }
    }
}
