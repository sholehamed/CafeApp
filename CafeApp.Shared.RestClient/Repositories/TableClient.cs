using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;
using CafeApp.Shared.RestClient.Interfaces;
using System.Net.Http.Json;

namespace CafeApp.Shared.RestClient.Repositories
{
    internal class TableClient : BaseClient<TableEntity>,ITableClient
    {
      

        public TableClient(HttpClient httpClient, string api):base(httpClient,api)
        {
            
        }

        public async Task<ICollection<DashboardTableModel>> GetDashboardTables()
        {
          var res=await  _httpClient.GetFromJsonAsync<ICollection<DashboardTableModel>>($"api/{_api}/dashboardtables");
            return res!;
        }
    }
}
