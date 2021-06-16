// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Linq.Expressions;
using Common.Services.Validation.Rules.Collections;

namespace Common.Services.Validation.Configuration
{
    public interface IValidationConfiguration
    {
        ValidationRuleCollection<TProperty> GetRuleCollection<TClass, TProperty>(
            Expression<Func<TClass, TProperty>> propertyExpression);

        void AddRuleCollection<TClass, TProperty>(
            Expression<Func<TClass, TProperty>> propertyExpression, 
            ValidationRuleCollection<TProperty> ruleCollection);
    }
}
