// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;
using Persistence.Services;

namespace Persistence.DependencyInjection
{
    public static class Dependencies
    {
        #region Public Methods

        public static IServiceCollection AddPersistenceDependencies(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("ApplicationContext")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddServices();
            services.AddRepositories();

            return services;
        }

        #endregion

        #region Private Methods

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IDatabaseInitializationService, DatabaseInitializationService>();
            services.AddTransient<IDatabaseScriptManager, DatabaseScriptManager>();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IDiaryRepository, DiaryRepository>();

            return services;
        }

        #endregion
    }
}
