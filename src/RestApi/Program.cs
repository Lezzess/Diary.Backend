// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Threading.Tasks;
using Core.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RestApi
{
    public class Program
    {
        #region Public Methods

        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            await InitializeApplication(host);
            await host.RunAsync();
        }

        #endregion

        #region Private Methods

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                       .ConfigureWebHostDefaults(
                           webBuilder => webBuilder.UseStartup<Startup>());
        }

        private static async Task InitializeApplication(IHost host)
        {
            using var scope = host.Services.CreateScope();

            var databaseInitializationService =
                scope.ServiceProvider.GetRequiredService<IDatabaseInitializationService>();
            await databaseInitializationService.InitializeDatabaseAsync();
        }

        #endregion
    }
}