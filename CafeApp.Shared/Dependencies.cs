using CafeApp.Business.Util;
using CafeApp.Domain.Interfaces;
using CafeApp.Shared.Interfaces;
using CafeApp.Shared.RestClient;
using CafeApp.Shared.Services;
using CafeApp.Shared.Util;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;

namespace CafeApp.Shared
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
             services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;

                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 10000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });
            services.AddMudBlazorDialog();
            services.AddScoped<INotification, NotificationService>();
            services.RegisterBusiness();
            services.RegisterRestClient();
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<ILocalStorageService, LocalStorageService>();
            services.AddScoped<IAccountService, AccountService>();

            return services;

        }
    }
}
