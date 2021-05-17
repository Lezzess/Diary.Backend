// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyInjection
{
    public static class Dependencies
    {
        #region Public Methods

        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            return services.AddTransient<IAssemblyResourceManager, AssemblyResourceManager>();
        }

        #endregion
    }
}
