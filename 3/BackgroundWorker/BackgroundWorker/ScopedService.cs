using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundWorker
{
    internal interface IScopedService
    {
        Task Run(CancellationToken sourceToken);
    }

    internal class ScopedService : IScopedService
    {
        private int _count = 0;

        // Setup Dependency Injection
        private readonly ILogger<ScopedService> _logger;

        public ScopedService(ILogger<ScopedService> logger)
        {
            _logger = logger;
        }

        // Run Application
        public async Task Run(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _count++;

                _logger.LogInformation("ScopedService Count: {count}", _count);

                await Task.Delay(4096, stoppingToken);
            }
        }
    }
}
