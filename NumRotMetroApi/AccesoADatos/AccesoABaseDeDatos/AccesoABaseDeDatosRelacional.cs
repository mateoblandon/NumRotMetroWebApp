using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace AccesoADatos.AccesoABaseDeDatos
{
    public class AccesoABaseDeDatosRelacional : IAccesoABaseDeDatosRelacional
    {
        private readonly IConfiguration _configuration;
        public AccesoABaseDeDatosRelacional(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "MySqlLocalHostConnection")
        {
            using IDbConnection connection = new MySqlConnection(_configuration.GetConnectionString(connectionId));
            return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "MySqlLocalHostConnection")
        {
            using IDbConnection connection = new MySqlConnection(_configuration.GetConnectionString(connectionId));
            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}