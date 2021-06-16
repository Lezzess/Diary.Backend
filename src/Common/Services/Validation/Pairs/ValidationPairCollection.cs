// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Common.Services.Validation.Configuration;

namespace Common.Services.Validation.Pairs
{
    internal class ValidationPairCollection
    {
        #region Dependencies

        private readonly IValidationConfiguration _validationConfiguration;

        #endregion

        #region Fields

        private readonly List<IValidationPair> _validationPairs;

        #endregion

        #region Constructors

        public ValidationPairCollection(IValidationConfiguration validationConfiguration)
        {
            _validationConfiguration = validationConfiguration;
            _validationPairs = new List<IValidationPair>();
        }

        #endregion

        #region Public Methods

        public ValidationPairCollection Add<TClass, TProperty>(
            TProperty valueToValidate,
            Expression<Func<TClass, TProperty>> propertyExpression)
        {
            var ruleCollection = _validationConfiguration.GetRuleCollection(propertyExpression);
            var validationPair = new ValidationPair<TProperty>(valueToValidate, ruleCollection);
            _validationPairs.Add(validationPair);

            return this;
        }

        public List<ValidationResult> Validate()
        {
            return _validationPairs.Select(pair => pair.Validate()).ToList();
        }

        #endregion
    }
}
