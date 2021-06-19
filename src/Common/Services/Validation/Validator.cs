// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Linq.Expressions;
using Common.Services.Validation.Configuration;
using Common.Services.Validation.Rules.Collections;

namespace Common.Services.Validation
{
    public abstract class Validator<TClass> : IValidator<TClass>
    {
        #region Dependencies

        private readonly IValidationConfiguration _validationConfiguration;

        #endregion

        #region Constructors

        protected Validator(IValidationConfiguration validationConfiguration)
        {
            _validationConfiguration = validationConfiguration;
        }

        #endregion

        #region Public Methods

        public void Validate<TProperty>(
            TProperty valueToValidate,
            Expression<Func<TClass, TProperty>> propertyExpression)
        {
            var ruleCollection = _validationConfiguration.GetRuleCollection(propertyExpression);
            ruleCollection.Validate(valueToValidate);
        }

        #endregion

        #region Protected Methods

        protected StringValidationRuleCollection Value(
            Expression<Func<TClass, string>> propertyExpression)
        {
            var ruleList = new StringValidationRuleCollection(propertyExpression);
            _validationConfiguration.AddRuleCollection(propertyExpression, ruleList);
            return ruleList;
        }

        protected IntValidationRuleCollection Value(
            Expression<Func<TClass, int>> propertyExpression)
        {
            var ruleList = new IntValidationRuleCollection(propertyExpression);
            _validationConfiguration.AddRuleCollection(propertyExpression, ruleList);
            return ruleList;
        }

        #endregion
    }
}
