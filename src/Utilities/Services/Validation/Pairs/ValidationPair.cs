// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Utilities.Services.Validation.Rules.Collections;

namespace Utilities.Services.Validation.Pairs
{
    internal class ValidationPair<TProperty> : IValidationPair
    {
        #region Fields

        private readonly TProperty _valueToValidate;
        private readonly ValidationRuleCollection<TProperty> _ruleCollection;

        #endregion

        #region Constructors

        public ValidationPair(TProperty valueToValidate, ValidationRuleCollection<TProperty> ruleCollection)
        {
            _valueToValidate = valueToValidate;
            _ruleCollection = ruleCollection;
        }

        #endregion

        #region Public Methods

        public ValidationResult Validate()
        {
            return _ruleCollection.Validate(_valueToValidate);
        }

        #endregion
    }
}
