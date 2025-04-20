using CafeApp.Domain.Entities;
using CafeApp.Shared.RestClient.Interfaces;

namespace CafeApp.Shared.RestClient.Repositories
{
    internal class AdditivesClient : BaseClient<AdditiveEntity>, IAdditivesClient
    {
        public AdditivesClient(HttpClient httpClient, string api) : base(httpClient, api)
        {
        }
    }
}
