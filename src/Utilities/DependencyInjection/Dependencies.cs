// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Linq;
using System.Reflection;
using Core.Services;
using CoreServices.Services.Resources;
using CoreServices.Services.Validation.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreServices.DependencyInjection
{
    public static class Dependencies
    {
        #region Public Methods

        public static IServiceCollection AddCoreServicesDependencies(this IServiceCollection services)
        {
            services.AddValidation();
            services.AddUtilities();
            
            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services, Assembly assembly)
        {
            var validatorGenericInterface = typeof(IValidator<>);
            var validators = assembly.DefinedTypes.Where(
                type => !type.IsGenericType &&
                        type.ImplementedInterfaces.Any(
                            @interface => @interface.IsGenericType &&
                                          @interface.GetGenericTypeDefinition() == validatorGenericInterface)).ToList();
            
            foreach (var validatorType in validators)
            {
                var validatorInterface = validatorType.GetInterfaces().First(
                    @interface => @interface.GetGenericTypeDefinition() == validatorGenericInterface);
                services.AddSingleton(validatorInterface, validatorType);
            }

            return services;
        }

        #endregion

        #region Private Methods

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddSingleton<IValidationConfiguration, ValidationConfiguration>();
            return services;
        }

        private static IServiceCollection AddUtilities(this IServiceCollection services)
        {
            services.AddTransient<IAssemblyResourceManager, AssemblyResourceManager>();
            return services;
        }

        #endregion
    }
}
