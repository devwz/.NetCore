using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundWorker
{
    public class ScheduledWorker : IHostedService, IDisposable
    {
        private int _count = 0;
        private Timer _timer;

        // Setup Dependency Injection
        private readonly ILogger<ScheduledWorker> _logger;

        public ScheduledWorker(ILogger<ScheduledWorker> logger)
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
            _logger.LogInformation("TimedWorker Count: {count}", count);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("TimedWorker Running.");
            _timer = new Timer(Run, null, TimeSpan.Zero, TimeSpan.FromSeconds(8));
            return Task.CompletedTask;
;        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("TimedWorker Stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
