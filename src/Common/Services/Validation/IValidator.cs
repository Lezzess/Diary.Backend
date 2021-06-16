// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Linq.Expressions;

namespace Common.Services.Validation
{
    public interface IValidator<TClass>
    {
        void Validate<TProperty>(
            TProperty valueToValidate,
            Expression<Func<TClass, TProperty>> propertyExpression);

        void Validate<TProperty1, TProperty2>(
            TProperty1 valueToValidate1,
            Expression<Func<TClass, TProperty1>> propertyExpression1,
            TProperty2 valueToValidate2,
            Expression<Func<TClass, TProperty2>> propertyExpression2);
    }
}
