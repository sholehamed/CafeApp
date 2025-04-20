using CafeApp.Domain.Entities;
using CafeApp.Shared.RestClient.Interfaces;

namespace CafeApp.Shared.RestClient.Repositories
{
    internal class CategoriesClient : BaseClient<ProductCategoryEntity>, ICategoriesClient
    {
        public CategoriesClient(HttpClient httpClient, string api) : base(httpClient, api)
        {
        }
    }
}
