// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Threading.Tasks;
using Core.Exceptions;
using Core.Exceptions.Validation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace RestApi.Middlewares
{
    internal class ExceptionHandlingMiddleware
    {
        #region Dependencies

        private readonly IWebHostEnvironment _environment;

        #endregion

        #region Fields

        private readonly RequestDelegate _next;

        #endregion

        #region Constructors

        public ExceptionHandlingMiddleware(RequestDelegate next, IWebHostEnvironment environment)
        {
            _next = next;
            _environment = environment;
        }

        #endregion

        #region Public Methods

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(e, context);
            }
        }

        #endregion

        #region Private Methods

        private async Task HandleExceptionAsync(Exception exception, HttpContext context)
        {
            var (statusCode, message) = exception switch
            {
                EntityNotFoundException e => GetEntityNotFoundExceptionResponseData(e),
                ValidationException e => GetValidationExceptionResponseData(e),
                { } e => GetUnknownExceptionResponseData(e)
            };

            context.Response.StatusCode = statusCode;

            if (_environment.IsDevelopment())
                await context.Response.WriteAsync(message);
            else
                await context.Response.CompleteAsync();
        }

        private static (int, string) GetEntityNotFoundExceptionResponseData(EntityNotFoundException exception)
        {
            return (StatusCodes.Status404NotFound, exception.Message);
        }

        private static (int, string) GetValidationExceptionResponseData(ValidationException exception)
        {
            return (StatusCodes.Status400BadRequest, exception.Message);
        }

        private static (int, string) GetUnknownExceptionResponseData(Exception exception)
        {
            var statusCode = StatusCodes.Status500InternalServerError;
            var message = $"Exception type: {exception.GetType()}\n"
                          + $"Exception message: {exception.Message}\n"
                          + $"Exception stack trace: {exception.StackTrace}";

            return (statusCode, message);
        }

        #endregion
    }
}
