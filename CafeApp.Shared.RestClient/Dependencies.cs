using CafeApp.Domain.Common;
using CafeApp.Shared.RestClient.Interfaces;
using CafeApp.Shared.RestClient.Util;
using Microsoft.Extensions.DependencyInjection;

namespace CafeApp.Shared.RestClient
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterRestClient(this IServiceCollection services)
        {
            services.AddSingleton<IRestUnit,RestUnit>();
            return services;
        }
    }
}
