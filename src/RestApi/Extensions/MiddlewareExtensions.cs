// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Microsoft.AspNetCore.Builder;
using RestApi.Middlewares;

namespace RestApi.Extensions
{
    internal static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(
            this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
