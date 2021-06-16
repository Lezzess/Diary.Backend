// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace Utilities.Services.Validation.Rules
{
    internal class ValidationRule<TValue>
    {
        #region Fields

        private readonly Func<TValue, bool> _isValidAction;

        #endregion

        #region Properties

        public string Message { get; }

        #endregion

        #region Constructor

        public ValidationRule(Func<TValue, bool> isValidAction, string message)
        {
            _isValidAction = isValidAction;
            Message = message;
        }

        #endregion

        #region Public Methods

        public bool IsValid(TValue value)
        {
            return _isValidAction(value);
        }

        #endregion
    }
}
