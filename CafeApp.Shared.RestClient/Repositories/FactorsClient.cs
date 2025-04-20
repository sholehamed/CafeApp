using CafeApp.Domain.Entities;
using CafeApp.Shared.RestClient.Interfaces;

namespace CafeApp.Shared.RestClient.Repositories
{
    internal class FactorsClient : BaseClient<InventoryFactorEntity>, IFactorsClient
    {
        public FactorsClient(HttpClient httpClient, string api) : base(httpClient, api)
        {
        }
    }
}
