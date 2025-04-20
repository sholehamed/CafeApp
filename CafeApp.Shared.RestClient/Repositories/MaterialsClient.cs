using CafeApp.Domain.Entities;
using CafeApp.Shared.RestClient.Interfaces;

namespace CafeApp.Shared.RestClient.Repositories
{
    internal class MaterialsClient : BaseClient<MaterialEntity>, IMaterialsClient
    {
        public MaterialsClient(HttpClient httpClient, string api) : base(httpClient, api)
        {
        }
    }
}
