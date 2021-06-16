// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Linq.Expressions;

namespace Utilities.Services.Validation.Rules.Collections
{
    public class IntValidationRuleCollection : ValidationRuleCollection<int>
    {
        #region Constructors

        public IntValidationRuleCollection(LambdaExpression propertyExpression) 
            : base(propertyExpression)
        {

        }

        #endregion

        #region Public Methods

        public IntValidationRuleCollection IsInRange(int minValue, int maxValue, string errorMessage = null)
        {
            MatchesIf(value => value >= minValue && value <= maxValue, errorMessage);
            return this;
        }

        #endregion
    }
}
