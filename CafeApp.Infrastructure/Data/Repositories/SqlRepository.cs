using CafeApp.Domain.Interfaces;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CafeApp.Infrastructure.Data.Repositories
{
    internal class SqlRepository(string connectionString) : ISql
    {
        private readonly string _connectionString = connectionString;

        public async Task ExecuteAsync(string command, CommandType commandType = CommandType.StoredProcedure, Dictionary<string, object>? parameters = null)
        {
            ArgumentNullException.ThrowIfNull(parameters);
            using SqlConnection _connection = new(_connectionString);
            await _connection.OpenAsync();
            await _connection.ExecuteAsync(command, parameters.Select(x => new SqlParameter(x.Key, x.Value)).ToArray(), commandType: commandType);
            await _connection.CloseAsync();
        }

        public async Task<object?> GetSacalarValueAsync(string command, CommandType commandType = CommandType.StoredProcedure, Dictionary<string, object>? parameters = null)
        {
            object? value;
            ArgumentNullException.ThrowIfNull(parameters);
            using (SqlConnection _connection = new(_connectionString))
            {
                await _connection.OpenAsync();
                value = await _connection.ExecuteScalarAsync(command, parameters.Select(x => new SqlParameter(x.Key, x.Value)).ToArray(), commandType: commandType);
                await _connection.CloseAsync();
            }
            return value;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string command, CommandType commandType = CommandType.StoredProcedure, Dictionary<string, object>? parameters = null)
        {
            IEnumerable<T> value = [];
            ArgumentNullException.ThrowIfNull(parameters);
            using (SqlConnection _connection = new(_connectionString))
            {
                await _connection.OpenAsync();
                value = await _connection.QueryAsync<T>(command, parameters.Select(x => new SqlParameter(x.Key, x.Value)).ToArray(), commandType: commandType);
                await _connection.CloseAsync();
            }
            return value;
        }
    }
}
