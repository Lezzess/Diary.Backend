// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Linq.Expressions;
using Utilities.Services.Validation.RuleCollections;

namespace Utilities.Services.Validation.Configuration
{
    public interface IValidationConfiguration
    {
        ValidationRuleList GetRuleList<TClass, TProperty>(
            Expression<Func<TClass, TProperty>> propertySelectionExpression);

        void AddRuleList<TClass, TProperty>(
            Expression<Func<TClass, TProperty>> propertySelectionExpression, 
            ValidationRuleList ruleList);
    }
}
