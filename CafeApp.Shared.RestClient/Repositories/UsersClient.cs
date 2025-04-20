using CafeApp.Domain.Entities;
using CafeApp.Shared.RestClient.Interfaces;

namespace CafeApp.Shared.RestClient.Repositories
{
    internal class UsersClient : BaseClient<UserEntity>, IUsersClient
    {
        public UsersClient(HttpClient httpClient, string api) : base(httpClient, api)
        {
        }
    }
}
