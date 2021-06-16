// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Collections.Generic;

namespace Core.Exceptions.Validation
{
    public class InputIsInvalidException : ValidationException
    {
        #region Properties

        public IReadOnlyCollection<string> Errors { get; }

        #endregion

        #region Constructors

        public InputIsInvalidException(IReadOnlyCollection<string> errors)
        {
            Errors = errors;
        }

        #endregion
    }
}
