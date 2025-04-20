using CafeApp.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CafeApp.Infrastructure.SqlServer
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterServerDb(this IServiceCollection services,string connectionString)
        {
           
            services.AddDbContext<CafeDbContext>(opt=>opt.UseSqlServer(connectionString));
            services.RegisterInfrastructure(connectionString);
            return services;
        }
    }
}
