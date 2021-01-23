using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

// https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/host/hosted-services

namespace BackgroundWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // Queued
        /*
        public static async Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            await host.StartAsync();

            var monitorLoop = host.Services.GetRequiredService<MonitorLoop>();
            monitorLoop.StartMonitorLoop();

            await host.WaitForShutdownAsync();
        }
        */

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // Scoped
                    services.AddScoped<IScopedService, ScopedService>();
                    services.AddHostedService<BackgroundScopedWorker>();

                    // Timed
                    services.AddHostedService<TimedService>();

                    // Queued
                    services.AddSingleton<MonitorLoop>();
                    services.AddHostedService<QueuedBackgroundService>();
                    services.AddSingleton<IBackgroundQueue, BackgroundQueue>();
                });
    }
}
