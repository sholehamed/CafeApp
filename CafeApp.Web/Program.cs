using CafeApp.Domain.Common;
using CafeApp.Domain.Interfaces;
using CafeApp.Hubs;
using CafeApp.Infrastructure.SqlServer;
using CafeApp.Shared;
using CafeApp.Shared.Layouts;
using CafeApp.Web.Components;
using CafeApp.Web.Util;
using Scalar.AspNetCore;
using Serilog;

namespace CafeApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.WebHost.ConfigureKestrel(opt =>
            {
                opt.Limits.MaxRequestBufferSize = 100 * 1024 * 1024;
                opt.Limits.MaxResponseBufferSize = 100 * 1024 * 1024;
                opt.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(5);


            });
            builder.Services.AddSingleton(new ServerOptions { Url = builder.Configuration.GetValue<string>("ServerUrl") });
            builder.Services.AddSingleton<IAuth, AuthService>();
            builder.Services.AddSignalR();
            builder.Services.AddSingleton<IPlatform, PlatformService>();
            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
            builder.Services.AddEndpointsApiExplorer();
            builder.Logging.AddConsole();
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);
            var log = new LoggerConfiguration()
        .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ServerUrl"));
            builder.Services.AddScoped(x => client);
            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents(x => x.DetailedErrors = true);
            builder.Services.RegisterServerDb(builder.Configuration.GetConnectionString("cafeDb"));
            builder.Services.RegisterAppServices();
            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            if (builder.Configuration.GetValue<bool>("ShowEndPoints"))
            {
                app.MapScalarApiReference("api");

            }


            app.MapControllers();
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddAdditionalAssemblies(typeof(AdminLayout).Assembly);
            app.MapHub<TableHub>("/TableHub");

            app.Run();
        }
    }
}
