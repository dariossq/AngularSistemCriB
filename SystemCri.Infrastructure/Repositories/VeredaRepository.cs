using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;
using SystemCri.Infrastructure.Data;

namespace SystemCri.Infrastructure.Repositories
{
    public class VeredaRepository : IVeredaRepository
    {
        private readonly ApplicationDbContext _context;

        public VeredaRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Vereda>> GetAllAsync()
        {
            var veredas = new List<Vereda>();
            var connection = _context.Database.GetDbConnection();
            await using var command = connection.CreateCommand();
            command.CommandText = "SELECT VEREDA_COD, VERADA_NOM, VEREDA_UBICACION, USUARIO_ID FROM VEREDA";

            if (connection.State != System.Data.ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                veredas.Add(new Vereda
                {
                    VeredaCod = reader.GetInt32(0),
                    VeredaNom = reader.GetString(1),
                    VeredaUbicacion = reader.IsDBNull(2) ? null : reader.GetString(2),
                    UsuarioId = reader.IsDBNull(3) ? null : reader.GetInt32(3)
                });
            }
            return veredas;
        }

        public async Task<IEnumerable<Vereda>> GetByUsuarioIdAsync(int usuarioId)
        {
            var veredas = new List<Vereda>();
            var connection = _context.Database.GetDbConnection();
            await using var command = connection.CreateCommand();
            command.CommandText = "SELECT VEREDA_COD, VERADA_NOM, VEREDA_UBICACION, USUARIO_ID FROM VEREDA WHERE USUARIO_ID = :usuarioId";

            var parameter = command.CreateParameter();
            parameter.ParameterName = ":usuarioId";
            parameter.Value = usuarioId;
            command.Parameters.Add(parameter);

            if (connection.State != System.Data.ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                veredas.Add(new Vereda
                {
                    VeredaCod = reader.GetInt32(0),
                    VeredaNom = reader.GetString(1),
                    VeredaUbicacion = reader.IsDBNull(2) ? null : reader.GetString(2),
                    UsuarioId = reader.IsDBNull(3) ? null : reader.GetInt32(3)
                });
            }
            return veredas;
        }

        public async Task<Vereda?> GetByIdAsync(int id)
        {
            var connection = _context.Database.GetDbConnection();
            await using var command = connection.CreateCommand();
            command.CommandText = "SELECT VEREDA_COD, VERADA_NOM, VEREDA_UBICACION, USUARIO_ID FROM VEREDA WHERE VEREDA_COD = :id";

            var parameter = command.CreateParameter();
            parameter.ParameterName = ":id";
            parameter.Value = id;
            command.Parameters.Add(parameter);

            if (connection.State != System.Data.ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            await using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Vereda
                {
                    VeredaCod = reader.GetInt32(0),
                    VeredaNom = reader.GetString(1),
                    VeredaUbicacion = reader.IsDBNull(2) ? null : reader.GetString(2),
                    UsuarioId = reader.IsDBNull(3) ? null : reader.GetInt32(3)
                };
            }
            return null;
        }

        public async Task AddAsync(Vereda vereda)
        {
            await _context.Veredas.AddAsync(vereda);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vereda vereda)
        {
            var connection = _context.Database.GetDbConnection();
            await using var command = connection.CreateCommand();
            command.CommandText = "UPDATE VEREDA SET VERADA_NOM = :veredaNom, VEREDA_UBICACION = :veredaUbicacion, USUARIO_ID = :usuarioId WHERE VEREDA_COD = :veredaCod";

            var param1 = command.CreateParameter();
            param1.ParameterName = ":veredaNom";
            param1.Value = vereda.VeredaNom ?? (object)System.DBNull.Value;
            command.Parameters.Add(param1);

            var param2 = command.CreateParameter();
            param2.ParameterName = ":veredaUbicacion";
            param2.Value = vereda.VeredaUbicacion ?? (object)System.DBNull.Value;
            command.Parameters.Add(param2);

            var param3 = command.CreateParameter();
            param3.ParameterName = ":usuarioId";
            param3.Value = vereda.UsuarioId ?? (object)System.DBNull.Value;
            command.Parameters.Add(param3);

            var param4 = command.CreateParameter();
            param4.ParameterName = ":veredaCod";
            param4.Value = vereda.VeredaCod;
            command.Parameters.Add(param4);

            if (connection.State != System.Data.ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(Vereda vereda)
        {
            var connection = _context.Database.GetDbConnection();
            await using var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM VEREDA WHERE VEREDA_COD = :veredaCod";

            var parameter = command.CreateParameter();
            parameter.ParameterName = ":veredaCod";
            parameter.Value = vereda.VeredaCod;
            command.Parameters.Add(parameter);

            if (connection.State != System.Data.ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            await command.ExecuteNonQueryAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var connection = _context.Database.GetDbConnection();
            await using var command = connection.CreateCommand();
            command.CommandText = "SELECT 1 FROM VEREDA WHERE VEREDA_COD = :id";

            var parameter = command.CreateParameter();
            parameter.ParameterName = ":id";
            parameter.Value = id;
            command.Parameters.Add(parameter);

            if (connection.State != System.Data.ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            await using var reader = await command.ExecuteReaderAsync();
            return await reader.ReadAsync();
        }
    }
}
