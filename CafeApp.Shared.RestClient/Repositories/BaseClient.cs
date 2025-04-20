using CafeApp.Shared.RestClient.Interfaces;
using System.Net.Http.Json;

namespace CafeApp.Shared.RestClient.Repositories
{
    internal class BaseClient<TEntity> : IBaseClient<TEntity>
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _api;

        public BaseClient(HttpClient httpClient, string api)
        {
            _httpClient = httpClient;
            _api = $"{api}";
        }

        public async Task Apply()
        {
           await _httpClient.GetAsync($"api/{_api}/apply");
        }

        public async Task<ICollection<TEntity>> Sync()
        {
            //var ress = await _httpClient.GetStringAsync($"api/{_api}/sync");
            var res = await _httpClient.GetFromJsonAsync<ICollection<TEntity>>($"api/{_api}/sync");
            return res!;
        }
        public async Task<TEntity> GetById(Guid id)
        {
            var res = await _httpClient.GetFromJsonAsync<TEntity>($"api/{_api}/{id}");
            return res!;
        }

        public async Task WriteSync(TEntity entity)
        {
            await _httpClient.PostAsJsonAsync($"api/{_api}/writesync",entity);
        }
    }
}
