// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Utilities.Services.Validation.Rules.Collections
{
    public abstract class ValidationRuleCollection
    {

    }

    public abstract class ValidationRuleCollection<TValue> : ValidationRuleCollection
    {
        #region Fields

        private readonly List<ValidationRule<TValue>> _rules;

        #endregion

        #region Properties

        public Type ClassType { get; }
        public string PropertyName { get; }

        #endregion

        #region Constructors

        protected ValidationRuleCollection(LambdaExpression propertyExpression)
        {
            _rules = new List<ValidationRule<TValue>>();

            var memberExpression = (MemberExpression)propertyExpression.Body;
            ClassType = memberExpression.Member.DeclaringType;
            PropertyName = memberExpression.Member.Name;
        }

        #endregion

        #region Public Methods

        public ValidationResult Validate(TValue value)
        {
            var result = new ValidationResult();
            foreach (var rule in _rules)
            {
                if (rule.IsValid(value))
                    continue;

                var errorMessage = rule.Message ?? GetDefaultErrorMessage(value);
                result.AddError(errorMessage);
            }

            return result;
        }

        #endregion

        #region Protected Methods
        
        protected void MatchesIf(Func<TValue, bool> rule, string message)
        {
            var validationRule = new ValidationRule<TValue>(rule, message);
            _rules.Add(validationRule);
        }

        #endregion

        #region Private Method

        private string GetDefaultErrorMessage(TValue value)
        {
            return $"The value {value} is not valid for the property {PropertyName} of type {ClassType.Name}";
        }

        #endregion
    }
}
