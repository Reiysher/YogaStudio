using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using YogaStudio.Persistence;
using Serilog;
using Serilog.Events;

namespace YogaStudio.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .WriteTo.File("YogaStudioWebAppLog-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                try
                {
                    var context = provider.GetRequiredService<YogaStudioDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "An error occured while app initialization");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
