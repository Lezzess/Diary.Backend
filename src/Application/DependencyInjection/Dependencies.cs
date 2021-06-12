// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Reflection;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection
{
    public static class Dependencies
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(
                Assembly.GetExecutingAssembly(),
                Assembly.GetAssembly(typeof(Persistence.DependencyInjection.Dependencies)));
            services.AddFluentValidation(
                configuration => configuration.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
