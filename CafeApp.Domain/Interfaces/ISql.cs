using System.Data;

namespace CafeApp.Domain.Interfaces
{
    public interface ISql
    {

        Task ExecuteAsync(string command, CommandType commandType = CommandType.StoredProcedure, Dictionary<string, object>? parameters = null);
        Task<object?> GetSacalarValueAsync(string command, CommandType commandType = CommandType.StoredProcedure, Dictionary<string, object>? parameters = null);
        Task<IEnumerable<T>> QueryAsync<T>(string command, CommandType commandType = CommandType.StoredProcedure, Dictionary<string, object>? parameters = null);

    }
}
