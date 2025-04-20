using CafeApp.Business.Helpers;
using CafeApp.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CafeApp.Business.Util
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterBusiness(this IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile<MapperProfile>());
            services.AddScoped<IApplicationUnit, ApplicationUnit>();
            return services;
        }
    }
}
