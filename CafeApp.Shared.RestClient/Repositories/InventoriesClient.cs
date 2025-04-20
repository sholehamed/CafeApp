using CafeApp.Domain.Entities;
using CafeApp.Shared.RestClient.Interfaces;

namespace CafeApp.Shared.RestClient.Repositories
{
    internal class InventoriesClient : BaseClient<InventoryEntity>, IInventoriesClient
    {
        public InventoriesClient(HttpClient httpClient, string api) : base(httpClient, api)
        {
        }
    }
}
