// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Linq.Expressions;

namespace Utilities.Services.Validation.Rules.Collections
{
    public class StringValidationRuleCollection : ValidationRuleCollection<string>
    {
        #region Constructors

        public StringValidationRuleCollection(LambdaExpression propertyExpression) 
            : base(propertyExpression)
        {

        }

        #endregion

        #region Public Methods

        public StringValidationRuleCollection IsNotEmpty(string errorMessage = null)
        {
            MatchesIf(value => !string.IsNullOrEmpty(value), errorMessage);
            return this;
        }

        public StringValidationRuleCollection HasMinLength(int length, string errorMessage = null)
        {
            MatchesIf(value => value.Length >= length, errorMessage);
            return this;
        }

        public StringValidationRuleCollection HasMaxLength(int length, string errorMessage = null)
        {
            MatchesIf(value => value.Length <= length, errorMessage);
            return this;
        }

        #endregion
    }
}
