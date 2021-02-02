using DependencyInjection.Common.Data;
using DependencyInjection.Common.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

// https://docs.microsoft.com/pt-br/dotnet/core/extensions/dependency-injection
// https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1#service-lifetimes

namespace DependencyInjection.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Setup Dependency Injection
            var provider = new ServiceCollection()
                .AddScoped<ICharacterDependency, CharacterDependency>()
                .AddSingleton<App>()
                .BuildServiceProvider();

            // Run Application
            provider.GetRequiredService<App>().Run();
        }
    }
}
