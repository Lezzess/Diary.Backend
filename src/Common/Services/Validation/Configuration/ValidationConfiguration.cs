// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Common.Services.Validation.Rules.Collections;
using Core.Exceptions;

namespace Common.Services.Validation.Configuration
{
    internal class ValidationConfiguration : IValidationConfiguration
    {
        #region Fields

        private readonly Dictionary<RuleCollectionKey, ValidationRuleCollection> _ruleCollections;

        #endregion

        #region Constructors

        public ValidationConfiguration()
        {
            _ruleCollections = new Dictionary<RuleCollectionKey, ValidationRuleCollection>();
        }

        #endregion

        #region Public Methods

        public ValidationRuleCollection<TProperty> GetRuleCollection<TClass, TProperty>(
            Expression<Func<TClass, TProperty>> propertyExpression)
        {
            var key = CreateKey(propertyExpression);

            if (!_ruleCollections.TryGetValue(key, out var ruleCollection))
            {
                throw new ValidationConfigurationException("Validation rule list does not exist for the property " 
                                                           + $"{key.PropertyName} of type {key.ClassType}");
            }

            return (ValidationRuleCollection<TProperty>)ruleCollection;
        }

        public void AddRuleCollection<TClass, TProperty>(
            Expression<Func<TClass, TProperty>> propertyExpression, 
            ValidationRuleCollection<TProperty> ruleCollection)
        {
            var key = CreateKey(propertyExpression);
            _ruleCollections.Add(key, ruleCollection);
        }

        #endregion

        #region Private Methods

        private static RuleCollectionKey CreateKey<TClass, TProperty>(
            Expression<Func<TClass, TProperty>> propertyExpression)
        {
            var classType = typeof(TClass);

            var memberExpression = (MemberExpression)propertyExpression.Body;
            var propertyName = memberExpression.Member.Name;

            return new RuleCollectionKey(classType, propertyName);
        }

        #endregion

        #region RuleCollectionKey record

        private record RuleCollectionKey(Type ClassType, string PropertyName);

        #endregion
    }
}
