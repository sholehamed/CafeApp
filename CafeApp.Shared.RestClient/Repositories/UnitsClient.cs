using CafeApp.Domain.Entities;
using CafeApp.Shared.RestClient.Interfaces;

namespace CafeApp.Shared.RestClient.Repositories
{
    internal class UnitsClient : BaseClient<UnitEntity>, IUnitsClient
    {
        public UnitsClient(HttpClient httpClient, string api) : base(httpClient, api)
        {
        }
    }
}
