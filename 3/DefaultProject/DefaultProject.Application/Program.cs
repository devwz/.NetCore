using Microsoft.Extensions.DependencyInjection;
using System;

namespace DefaultProject.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Setup Dependency Injection
            var provider = new ServiceCollection()
                .AddSingleton<App>()
                .BuildServiceProvider();

            // Run Application
            provider.GetRequiredService<App>().Run();
        }
    }
}
