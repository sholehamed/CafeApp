using CafeApp.Domain.Entities;
using CafeApp.Shared.RestClient.Interfaces;

namespace CafeApp.Shared.RestClient.Repositories
{
    internal class OrdersClient : BaseClient<OrderEntity>, IOrdersClient
    {
        public OrdersClient(HttpClient httpClient, string api) : base(httpClient, api)
        {
        }
    }
}
