// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Exceptions.Validation;
using Core.Services;
using Utilities.Services.Validation.Configuration;
using Utilities.Services.Validation.Pairs;
using Utilities.Services.Validation.Rules.Collections;

namespace Utilities.Services.Validation
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
            EnsureValidationResultsHaveNoErrors(
                new ValidationPairCollection(_validationConfiguration)
                    .Add(valueToValidate, propertyExpression)
                    .Validate());
        }

        public void Validate<TProperty1, TProperty2>(
            TProperty1 valueToValidate1, 
            Expression<Func<TClass, TProperty1>> propertyExpression1,
            TProperty2 valueToValidate2, 
            Expression<Func<TClass, TProperty2>> propertyExpression2)
        {
            EnsureValidationResultsHaveNoErrors(
                new ValidationPairCollection(_validationConfiguration)
                    .Add(valueToValidate1, propertyExpression1)
                    .Add(valueToValidate2, propertyExpression2)
                    .Validate());
        }

        #endregion

        #region Protected Methods

        protected GuidValidationRuleCollection Value(
            Expression<Func<TClass, Guid>> propertyExpression)
        {
            var ruleList = new GuidValidationRuleCollection(propertyExpression);
            _validationConfiguration.AddRuleCollection(propertyExpression, ruleList);
            return ruleList;
        }

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

        #region Private Methods

        private static void EnsureValidationResultsHaveNoErrors(IEnumerable<ValidationResult> validationResults)
        {
            var combinedResult = ValidationResult.Combine(validationResults);
            if (!combinedResult.IsValid)
                throw new InputIsInvalidException(combinedResult.Errors);
        }

        #endregion
    }
}
