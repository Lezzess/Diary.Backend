// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Linq.Expressions;

namespace Utilities.Services.Validation.Rules.Collections
{
    public class GuidValidationRuleCollection : ValidationRuleCollection<Guid>
    {
        #region Constructors

        public GuidValidationRuleCollection(LambdaExpression propertyExpression) 
            : base(propertyExpression)
        {

        }

        #endregion

        #region Public Methods

        public GuidValidationRuleCollection IsNotEmpty(string errorMessage = null)
        {
            MatchesIf(value => value != Guid.Empty, errorMessage);
            return this;
        }

        #endregion
    }
}
