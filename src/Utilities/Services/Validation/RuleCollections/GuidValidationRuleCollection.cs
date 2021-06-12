// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace Utilities.Services.Validation.RuleCollections
{
    public class GuidValidationRuleCollection : ValidationRuleCollection<Guid?>
    {
        public GuidValidationRuleCollection IsNotNullOrEmpty()
        {
            MatchesIf(value => value != null && value != Guid.Empty);
            return this;
        }
    }
}
