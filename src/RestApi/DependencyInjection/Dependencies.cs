// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Microsoft.Extensions.DependencyInjection;

namespace RestApi.DependencyInjection
{
    public static class Dependencies
    {
        #region Constants

        private const string FrontendDevelopmentDomain = "http://localhost:4200";

        #endregion

        #region Public Methods

        public static IServiceCollection AddRestApiDependencies(this IServiceCollection services)
        {
            services.AddCors(
                options => options.AddDefaultPolicy(
                    builder => builder.WithOrigins(FrontendDevelopmentDomain)));

            services.AddControllers();

            return services;
        }

        #endregion
    }
}
