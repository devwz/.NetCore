using EntityFramework.Common.Data;
using EntityFramework.Common.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EntityFramework.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Setup Dependency Injection
            var services = new ServiceCollection();
            ConfigureServices(services);

            var provider = services.BuildServiceProvider();

            // Run Application
            provider.GetRequiredService<App>().Run();
        }

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                const string connectionString = @"Server=(LocalDb)\MSSqlLocalDb;Initial Catalog=EntityFrameworkCodeFirst;Integrated Security=True";
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<ICharacterDependency, CharacterDependency>();

            services.AddSingleton<App>();
        }
    }
}
