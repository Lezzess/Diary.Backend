// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Reflection;
using Common.DependencyInjection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection
{
    public static class Dependencies
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidators(Assembly.GetExecutingAssembly());
            
            return services;
        }
    }
}
