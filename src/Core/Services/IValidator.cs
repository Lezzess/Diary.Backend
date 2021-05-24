// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Linq.Expressions;

namespace Core.Services
{
    public interface IValidator<TClass>
    {
        void Validate<TValue, TProperty>(
            TValue valueToValidate, 
            Expression<Func<TClass, TProperty>> propertySelectionExpression) 
            where TValue : class;

        void Validate<TValue, TProperty>(
            TValue? valueToValidate, 
            Expression<Func<TClass, TProperty>> propertySelectionExpression) 
            where TValue : struct;
    }
}
