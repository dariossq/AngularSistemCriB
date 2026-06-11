using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Oracle.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCri.Domain.Interfaces;
using SystemCri.Infrastructure.Data;
using SystemCri.Infrastructure.Repositories;

namespace SystemCri.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlConnectionString = configuration.GetConnectionString("ConexionSQL");
            var oracleConnectionString = configuration.GetConnectionString("ConexionOracle");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                if (!string.IsNullOrWhiteSpace(oracleConnectionString))
                {
                    options.UseOracle(oracleConnectionString);
                }
                else if (!string.IsNullOrWhiteSpace(sqlConnectionString))
                {
                    options.UseSqlServer(sqlConnectionString);
                }
                else
                {
                    throw new InvalidOperationException("No se ha configurado ninguna cadena de conexión válida. Configure ConexionOracle o ConexionSQL.");
                }
            });

            // Registrar repositorios: interfaz -> implementación concreta
            services.AddScoped<IDeptoRepository, DeptoRepository>();
            services.AddScoped<IMunicipioRepository, MunicipioRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IAccesoRepository, AccesoRepository>();
            services.AddScoped<IVeredaRepository, VeredaRepository>();
            services.AddScoped<ISeguridadRepository, SeguridadRepository>();
            services.AddScoped<ITipoCargoTrabajoRepository, TipoCargoTrabajoRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<IEscolaridadRepository, EscolaridadRepository>();
            services.AddScoped<IFamiliaRepository, FamiliaRepository>();
            services.AddScoped<IProfesinRepository, ProfesinRepository>();
            services.AddScoped<IEstadocivilRepository, EstadocivilRepository>();
           
            return services;
        }
    }
}
