// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Linq.Expressions;
using Core.Services;
using CoreServices.Services.Validation.Configuration;
using CoreServices.Services.Validation.RuleCollections;

namespace CoreServices.Services.Validation.Validators
{
    internal abstract class Validator<TClass> : IValidator<TClass>
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

        public void Validate<TValue, TProperty>(
            TValue valueToValidate, 
            Expression<Func<TClass, TProperty>> propertySelectionExpression) 
            where TValue : class
        {
            var ruleList = _validationConfiguration.GetRuleList(propertySelectionExpression);
            var convertedRuleList = (ValidationRuleCollection<TValue>)ruleList;
            convertedRuleList.Validate(valueToValidate);
        }

        public void Validate<TValue, TProperty>(
            TValue? valueToValidate, 
            Expression<Func<TClass, TProperty>> propertySelectionExpression) 
            where TValue : struct
        {
            var ruleList = _validationConfiguration.GetRuleList(propertySelectionExpression);
            var convertedRuleList = (ValidationRuleCollection<TValue?>)ruleList;
            convertedRuleList.Validate(valueToValidate);
        }

        #endregion

        #region Protected Methods

        protected StringValidationRuleCollection Value(
            Expression<Func<TClass, string>> propertySelectionExpression)
        {
            var ruleList = new StringValidationRuleCollection();
            _validationConfiguration.AddRuleList(propertySelectionExpression, ruleList);
            return ruleList;
        }

        protected IntValidationRuleCollection Value(
            Expression<Func<TClass, int>> propertySelectionExpression)
        {
            var ruleList = new IntValidationRuleCollection();
            _validationConfiguration.AddRuleList(propertySelectionExpression, ruleList);
            return ruleList;
        }

        #endregion
    }
}
