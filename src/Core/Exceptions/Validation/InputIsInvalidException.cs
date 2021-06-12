// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Collections.Generic;
using FluentValidation.Results;

namespace Core.Exceptions.Validation
{
    public class InputIsInvalidException : ValidationException
    {
        public InputIsInvalidException(List<ValidationFailure> errors)
            : base(errors.ToString())
        {

        }
    }
}
