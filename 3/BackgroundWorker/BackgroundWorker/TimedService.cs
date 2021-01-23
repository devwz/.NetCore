using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundWorker
{
    public class TimedService : IHostedService, IDisposable
    {
        private int _count = 0;
        private Timer _timer;

        // Setup Dependency Injection
        private readonly ILogger<TimedService> _logger;

        public TimedService(ILogger<TimedService> logger)
        {
            _logger = logger;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        // Run Application
        public void Run(object state)
        {
            int count = Interlocked.Increment(ref _count);
            _logger.LogInformation("TimedService count: {count}", count);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("TimedService running.");
            _timer = new Timer(Run, null, TimeSpan.Zero, TimeSpan.FromSeconds(8));

            return Task.CompletedTask;
;        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("TimedService stopping.");
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
    }
}
