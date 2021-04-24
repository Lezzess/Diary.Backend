// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Services;

namespace Persistence.DependencyInjection
{
    public static class Dependencies
    {
        #region Public Methods

        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services)
        {
            return services.AddTransient<IDiaryRepository, DiaryRepository>();
        }

        #endregion
    }
}
