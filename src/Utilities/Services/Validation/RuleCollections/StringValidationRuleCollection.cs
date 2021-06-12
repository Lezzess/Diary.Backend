// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace Utilities.Services.Validation.RuleCollections
{
    public class StringValidationRuleCollection : ValidationRuleCollection<string>
    {
        public StringValidationRuleCollection Trim()
        {
            Setup(value => value.Trim());
            return this;
        }

        public StringValidationRuleCollection IsNotNullOrEmpty()
        {
            MatchesIf(value => !string.IsNullOrEmpty(value));
            return this;
        }

        public StringValidationRuleCollection HasMinLength(int length)
        {
            MatchesIf(value => value.Length >= length);
            return this;
        }

        public StringValidationRuleCollection HasMaxLength(int length)
        {
            MatchesIf(value => value.Length <= length);
            return this;
        }
    }
}
