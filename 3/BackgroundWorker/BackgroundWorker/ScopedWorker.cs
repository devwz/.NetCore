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
    public class ScopedWorker : BackgroundService
    {
        private readonly ILogger<ScopedWorker> _logger;

        public ScopedWorker(
            IServiceProvider services,
            ILogger<ScopedWorker> logger)
        {
            Services = services;
            _logger = logger;
        }

        public IServiceProvider Services { get; set; }

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
