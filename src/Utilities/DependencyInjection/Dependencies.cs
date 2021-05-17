// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Microsoft.Extensions.DependencyInjection;
using Utilities.Services;

namespace Utilities.DependencyInjection
{
    public static class Dependencies
    {
        #region Public Methods

        public static IServiceCollection AddUtilitiesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IAssemblyResourceManager, AssemblyResourceManager>();
            return services;
        }

        #endregion
    }
}
