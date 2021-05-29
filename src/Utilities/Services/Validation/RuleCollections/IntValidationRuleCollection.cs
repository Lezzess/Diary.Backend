// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace CoreServices.Services.Validation.RuleCollections
{
    public class IntValidationRuleCollection : ValidationRuleCollection<int?>
    {
        #region Public Methods

        public IntValidationRuleCollection IsNotNull()
        {
            MatchesIf(value => value != null);
            return this;
        }

        public IntValidationRuleCollection IsInRange(int minValue, int maxValue)
        {
            MatchesIf(value => value >= minValue && value <= maxValue);
            return this;
        }

        #endregion
    }
}
