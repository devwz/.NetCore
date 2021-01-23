using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundWorker
{
    public class MonitorLoop
    {
        private readonly IBackgroundQueue _queue;
        private readonly ILogger _logger;
        private readonly CancellationToken _cancellationToken;

        public MonitorLoop(
            IBackgroundQueue queue,
            ILogger<MonitorLoop> logger,
            IHostApplicationLifetime applicationLifetime)
        {
            _queue = queue;
            _logger = logger;
            _cancellationToken = applicationLifetime.ApplicationStopping;
        }

        public void StartMonitorLoop()
        {
            _logger.LogInformation("MonitorLoop starting.");

            // Run input loop in a background thread
            Task.Run(() => Monitor());
        }

        public void Monitor()
        {
            while (!_cancellationToken.IsCancellationRequested)
            {
                var keyStroke = Console.ReadKey();

                if (keyStroke.Key == ConsoleKey.W)
                {
                    // Enqueue a background work item
                    _queue.QueueBackgroundWorkItem(async token =>
                    {
                        // Simulate three 6 second to complete
                        // for each enqueued work item
                        int delayLoop = 0;
                        string guid = Guid.NewGuid().ToString();

                        _logger.LogInformation("Queued Background Task {Guid} starting.", guid);

                        while (!token.IsCancellationRequested && delayLoop < 3)
                        {
                            try
                            {
                                await Task.Delay(TimeSpan.FromSeconds(6), token);
                            }
                            catch (OperationCanceledException)
                            {
                                // Prevent throwing if the Delay is cancelled
                            }

                            delayLoop++;

                            _logger.LogInformation("Queued Background Task {Guid} running. " +
                                "{DelayLoop}/3", guid, delayLoop);
                        }

                        if (delayLoop == 3)
                        {
                            _logger.LogInformation("Queued Background Task {Guid} complete.", guid);
                        }
                        else
                        {
                            _logger.LogInformation("Queued Background Task {Guid} cancelled.", guid);
                        }
                    });
                }
            }
        }
    }
}
