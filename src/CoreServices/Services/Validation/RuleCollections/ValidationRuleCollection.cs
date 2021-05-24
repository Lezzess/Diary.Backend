// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;
using Core.Exceptions;

namespace CoreServices.Services.Validation.RuleCollections
{
    internal abstract class ValidationRuleList
    {

    }

    internal abstract class ValidationRuleCollection<TValue> : ValidationRuleList
    {
        #region Fields

        private readonly List<Func<TValue, TValue>> _setups = new();
        private readonly List<Func<TValue, bool>> _rules = new();

        #endregion
        
        #region Public Methods

        public void Validate(TValue value)
        {
            var formattedValue = _setups.Aggregate(
                value, 
                (current, setupValue) => 
                    current == null ? default : setupValue(current));

            if (_rules.Any(matchesRule => !matchesRule(formattedValue)))
                throw new ValidationException($"Value {value} is invalid");
        }

        #endregion

        #region Protected Methods

        protected void Setup(Func<TValue, TValue> setup)
        {
            _setups.Add(setup);
        }

        protected void MatchesIf(Func<TValue, bool> rule)
        {
            _rules.Add(rule);
        }

        #endregion
    }
}
