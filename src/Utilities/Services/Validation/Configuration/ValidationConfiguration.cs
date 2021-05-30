// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Exceptions;
using Utilities.Services.Validation.RuleCollections;

namespace Utilities.Services.Validation.Configuration
{
    internal class ValidationConfiguration : IValidationConfiguration
    {
        #region Fields

        private readonly Dictionary<RuleCollectionKey, ValidationRuleList> _ruleCollections = new();

        #endregion

        #region Public Methods

        public ValidationRuleList GetRuleList<TClass, TProperty>(
            Expression<Func<TClass, TProperty>> propertySelectionExpression)
        {
            var key = CreateKey(propertySelectionExpression);

            if (!_ruleCollections.TryGetValue(key, out var ruleList))
            {
                throw new ValidationConfigurationException("Validation rule list does not exist for the property " 
                                                           + $"{key.PropertyName} of type {key.ClassType}");
            }

            return ruleList;
        }

        public void AddRuleList<TClass, TProperty>(
            Expression<Func<TClass, TProperty>> propertySelectionExpression, 
            ValidationRuleList ruleList)
        {
            var key = CreateKey(propertySelectionExpression);
            _ruleCollections.Add(key, ruleList);
        }

        #endregion

        #region Private Methods

        private static RuleCollectionKey CreateKey<TClass, TValue>(
            Expression<Func<TClass, TValue>> propertySelectionExpression)
        {
            var classType = typeof(TClass);

            var memberExpression = (MemberExpression)propertySelectionExpression.Body;
            var propertyName = memberExpression.Member.Name;

            return new(classType, propertyName);
        }

        #endregion

        #region RuleCollectionKey record

        private record RuleCollectionKey(Type ClassType, string PropertyName);

        #endregion
    }
}
