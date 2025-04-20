using CafeApp.Domain.Entities;
using CafeApp.Shared.RestClient.Interfaces;

namespace CafeApp.Shared.RestClient.Repositories
{
    internal class CustomersClient : BaseClient<CustomerEntity>, ICustomersClient
    {
        public CustomersClient(HttpClient httpClient, string api) : base(httpClient, api)
        {
        }
    }
}
