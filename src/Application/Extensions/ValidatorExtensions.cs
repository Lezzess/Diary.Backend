// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Exceptions.Validation;
using FluentValidation;
using FluentValidation.Internal;

namespace Application.Extensions
{
    internal static class ValidatorExtensions
    {
        public static async Task ValidateStrictAsync<T>(
            this IValidator<T> validator,
            T instance,
            Action<ValidationStrategy<T>> options,
            CancellationToken cancellationToken = default)
        {
            var validationResult = await validator.ValidateAsync(instance, options, cancellationToken);
            if (validationResult.IsValid)
                return;

            throw new InputIsInvalidException(validationResult.Errors);
        }
    }
}
