// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Collections.Generic;
using System.Linq;

namespace Common.Services.Validation
{
    public class ValidationResult
    {
        #region Fields

        private readonly List<string> _errors;

        #endregion

        #region Properties

        public bool IsValid => !Errors.Any();
        public IReadOnlyCollection<string> Errors => _errors;

        #endregion

        #region Constructor

        internal ValidationResult()
        {
            _errors = new List<string>();
        }

        #endregion

        #region Internal Methods

        internal void AddError(string error)
        {
            _errors.Add(error);
        }

        internal static ValidationResult Combine(IEnumerable<ValidationResult> results)
        {
            var validationResult = new ValidationResult();
            foreach (var result in results)
                validationResult.AddErrors(result.Errors);

            return validationResult;
        }

        #endregion

        #region Private Methods

        private void AddErrors(IEnumerable<string> errors)
        {
            _errors.AddRange(errors);
        }

        #endregion
    }
}
