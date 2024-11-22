using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace EnergyAwareness.Services
{
    public class OracleService
    {
        private readonly string _connectionString;

        public OracleService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> CalcularConsumoTotalAsync(int idUsuario)
        {
            using (IDbConnection dbConnection = new OracleConnection(_connectionString))
            {
                var parameters = new { id_usuario = idUsuario };
                var resultado = await dbConnection.QuerySingleAsync<int>(
                    "SELECT CalcularConsumoTotal(@id_usuario) FROM dual", parameters
                );
                return resultado;
            }
        }

        public async Task<bool> ValidarCpfAsync(long cpf)
        {
            using (IDbConnection dbConnection = new OracleConnection(_connectionString))
            {
                var parameters = new { nr_cpf = cpf };
                var resultado = await dbConnection.QuerySingleAsync<bool>(
                    "SELECT ValidarCPF(@nr_cpf) FROM dual", parameters
                );
                return resultado;
            }
        }
    }
}