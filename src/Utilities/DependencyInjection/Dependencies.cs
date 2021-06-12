// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Utilities.Services.Resources;

namespace Utilities.DependencyInjection
{
    public static class Dependencies
    {
        #region Public Methods

        public static IServiceCollection AddCoreServicesDependencies(this IServiceCollection services)
        {
            services.AddUtilities();
            return services;
        }

        #endregion

        #region Private Methods

        private static IServiceCollection AddUtilities(this IServiceCollection services)
        {
            services.AddTransient<IAssemblyResourceManager, AssemblyResourceManager>();
            return services;
        }

        #endregion
    }
}
