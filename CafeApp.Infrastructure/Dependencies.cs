using CafeApp.Domain.Interfaces;
using CafeApp.Infrastructure.Data;
using CafeApp.Infrastructure.Data.Util;
using Microsoft.Extensions.DependencyInjection;

namespace CafeApp.Infrastructure
{
    internal static class Dependencies
    {
        internal static IServiceCollection RegisterInfrastructure(this IServiceCollection services,string connectionString)
        {
            {
                
                services.AddSingleton(new DbOptions { ConnectionString = connectionString });
                services.AddScoped<IDataUnit, DataUnit>();
                return services;
            }
        }
    }
}
