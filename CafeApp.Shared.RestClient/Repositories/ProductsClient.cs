using CafeApp.Domain.Entities;
using CafeApp.Shared.RestClient.Interfaces;

namespace CafeApp.Shared.RestClient.Repositories
{
    internal class ProductsClient : BaseClient<ProductEntity>, IProductClient
    {
        public ProductsClient(HttpClient httpClient, string api) : base(httpClient, api)
        {
        }
    }
}
