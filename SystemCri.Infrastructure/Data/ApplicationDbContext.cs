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
        public DbSet<Acceso> Accesos => Set<Acceso>();
        public DbSet<Vereda> Veredas => Set<Vereda>();
        public DbSet<Seguridad> Seguridads => Set<Seguridad>();
        public DbSet<TipoCargoTrabajo> TipoCargoTrabajos => Set<TipoCargoTrabajo>();
        public DbSet<Genero> Generos => Set<Genero>();
        public DbSet<Escolaridad> Escolaridads => Set<Escolaridad>();
        public DbSet<Familia> Familias => Set<Familia>();
        public DbSet<Profesion> Profesions => Set<Profesion>();
        public DbSet<Estadocivil> Estadocivils => Set<Estadocivil>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Profesion ANTES del foreach automático
            modelBuilder.Entity<Profesion>(entity =>
            {
                entity.ToTable("PROFISION");
                entity.Property(e => e.ProfCod).HasColumnName("PROFISION_COD");
                entity.Property(e => e.ProfNombre).HasColumnName("PROFISION_NOM");
                entity.Property(e => e.ProfDescrip).HasColumnName("PROFISION_DESCRIP");
            });

            // Configuración de Estadocivil ANTES del foreach automático
            modelBuilder.Entity<Estadocivil>(entity =>
            {
                entity.ToTable("ESTADOCIVIL");
                entity.Property(e => e.EstadocCod).HasColumnName("ESTADOC_COD");
                entity.Property(e => e.EstadocNom).HasColumnName("ESTADOC_NOM");
                entity.Property(e => e.EstadocDescrip).HasColumnName("ESTADOC_DESCRIP");
            });

            modelBuilder.Entity<Depto>().ToTable("DEPTO");
            modelBuilder.Entity<Municipio>().ToTable("MUNICIPIO");
            modelBuilder.Entity<Usuario>().ToTable("USUARIO");
            modelBuilder.Entity<Acceso>().ToTable("ACCESO");
            modelBuilder.Entity<Vereda>().ToTable("VEREDA");
            modelBuilder.Entity<Seguridad>().ToTable("SEGURIDAD");
            modelBuilder.Entity<Genero>().ToTable("GENERO");
            modelBuilder.Entity<Escolaridad>().ToTable("ESCOLARIDAD");

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Skip Profesion y Estadocivil - ya están configuradas
                if (entityType.ClrType == typeof(Profesion) || entityType.ClrType == typeof(Estadocivil)) continue;

                entityType.SetTableName(ToOracleName(entityType.GetTableName()));

                foreach (var property in entityType.GetProperties())
                {
                    property.SetColumnName(ToOracleName(property.Name));
                }
            }

            modelBuilder.Entity<Vereda>(entity =>
            {
                entity.Property(v => v.VeredaCod).HasColumnName("VEREDA_COD");
                entity.Property(v => v.VeredaNom).HasColumnName("VERADA_NOM");
                entity.Property(v => v.VeredaUbicacion).HasColumnName("VEREDA_UBICACION");
                entity.Property(v => v.UsuarioId).HasColumnName("USUARIO_ID");
            });

            modelBuilder.Entity<Seguridad>(entity =>
            {
                entity.Property(s => s.PerCod).HasColumnName("PER_COD");
                entity.Property(s => s.SeguridadPer).HasColumnName("SEGURIDAD_PER");
                entity.Property(s => s.SeguridadContra).HasColumnName("SEGURIDAD_CONTRA");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.ToTable("GENERO");
                entity.Property(e => e.GeneroCod).HasColumnName("GENERO_COD");
                entity.Property(e => e.GeneroNom).HasColumnName("GENERO_NOM");
                entity.Property(e => e.GeneroSigla).HasColumnName("GENERO_SIGLA");
            });

            modelBuilder.Entity<Escolaridad>(entity =>
            {
                entity.ToTable("ESCOLARIDAD");
                entity.Property(e => e.EscolaridadCod).HasColumnName("ESCOLARIDAD_COD");
                entity.Property(e => e.EscolaridadNom).HasColumnName("ESCOLARIDAD_NOM");
                entity.Property(e => e.EscolaridadDescrip).HasColumnName("ESCOLARIDAD_DESCRIP");
            });

            modelBuilder.Entity<Familia>(entity =>
            {
                entity.ToTable("FAMILIA");
                entity.Property(e => e.FamCod).HasColumnName("FAM_COD");
                entity.Property(e => e.FamNombre).HasColumnName("FAM_NOMBRE");
                entity.Property(e => e.FamDescrip).HasColumnName("FAM_DESCRIP");
            });

            modelBuilder.Entity<TipoCargoTrabajo>(entity =>
            {
                entity.ToTable("TIPO_CARGO_TRABAJO");
                entity.Property(e => e.TicaCod).HasColumnName("TICA_COD");
                entity.Property(e => e.TicaNombre).HasColumnName("TICA_NOMBRE");
                entity.Property(e => e.TicaDescrip).HasColumnName("TICA_DESCRIP");
            });

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

            // Configuración explícita de la relación Acceso -> Usuario
            modelBuilder.Entity<Acceso>()
                .HasOne(a => a.Usuario)
                .WithMany(u => u.Accesos)
                .HasForeignKey(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            // Columnas especiales que no siguen la convención de nombres exacta en Oracle
            modelBuilder.Entity<Acceso>(entity =>
            {
                entity.Property(a => a.FechaIAcceso).HasColumnName("FECH_I_ACCESO");
                entity.Property(a => a.FechaFAcceso).HasColumnName("FECH_F_ACCESO");
            });

            modelBuilder.Entity<Vereda>()
                .HasOne(v => v.Usuario)
                .WithMany(u => u.Veredas)
                .HasForeignKey(v => v.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);
        }

        private static string ToOracleName(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return name ?? string.Empty;
            }

            var builder = new StringBuilder();
            for (var i = 0; i < name.Length; i++)
            {
                var c = name[i];
                if (char.IsUpper(c) && i > 0 && name[i - 1] != '_' && !char.IsUpper(name[i - 1]))
                {
                    builder.Append('_');
                }

                builder.Append(char.ToUpperInvariant(c));
            }

            return builder.ToString();
        }
    }
}
