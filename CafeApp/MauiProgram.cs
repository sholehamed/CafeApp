using CafeApp.Domain.Common;
using CafeApp.Domain.Interfaces;
using CafeApp.Infrastructure.LocalDb;
using CafeApp.Shared;
using CafeApp.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CafeApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            var stream = FileSystem.Current.OpenAppPackageFileAsync("appsettings.json").Result;

            var configurationBuilder = new ConfigurationBuilder()
             .SetBasePath(AppContext.BaseDirectory)
             .AddJsonStream(stream);

            IConfiguration configuration = configurationBuilder.Build();
            builder.Configuration.AddConfiguration(configuration);
            builder.Services.AddScoped<IAuth, AuthService>();
            builder.Services.AddSingleton<IPlatform, Util.PlatformService>();
            builder.Services.AddSingleton(new ServerOptions { Url = builder.Configuration.GetValue<string>("ServerUrl")! });
            builder.Services.RegisterLocalDb("cafeDb");
            builder.Services.RegisterAppServices();

            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();


            return builder.Build();
        }
    }
}
