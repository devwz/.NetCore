using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundWorker
{
    public class BackgroundScopedWorker : BackgroundService
    {
        private readonly ILogger<BackgroundScopedWorker> _logger;

        public BackgroundScopedWorker(
            IServiceProvider services,
            ILogger<BackgroundScopedWorker> logger)
        {
            Services = services;
            _logger = logger;
        }

        public IServiceProvider Services { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("BackgroundScopedWorker running.");

            await Run(stoppingToken);
        }

        private async Task Run(CancellationToken stoppingToken)
        {
            _logger.LogInformation("BackgroundScopedWorker working.");

            using (var scope = Services.CreateScope())
            {
                var scopedService =
                    scope.ServiceProvider
                        .GetRequiredService<IScopedService>();

                await scopedService.Run(stoppingToken);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
