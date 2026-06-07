using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            var connectionString = configuration.GetConnectionString("ConexionSQL");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));          

            // Registrar repositorios: interfaz -> implementación concreta
            services.AddScoped<IDeptoRepository, DeptoRepository>();
            services.AddScoped<IMunicipioRepository, MunicipioRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
           
            return services;
        }
    }
}
