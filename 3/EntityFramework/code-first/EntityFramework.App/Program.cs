using EntityFramework.Common.Data;
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
            var provider = new ServiceCollection()
                .AddDbContext<ApplicationDbContext>(options =>
                {
                    const string ConnectionString = "Server=(LocalDb)\\MSSqlLocalDb;Initial Catalog=EntityFrameworkCodeFirst;Integrated Security=True";
                    options.UseSqlServer(ConnectionString);
                })
                .AddScoped<CharacterDependency>()
                .AddSingleton<App>()
                .BuildServiceProvider();

            // Run Application
            provider.GetRequiredService<App>().Run();
        }
    }
}
