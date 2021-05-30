using Core.Models;
using Utilities.Services.Validation.Configuration;
using Utilities.Services.Validation.Validators;

namespace Application.Validators
{
    internal class DiaryEntryValidator : Validator<DiaryEntry>
    {
        #region Constructor

        public DiaryEntryValidator(IValidationConfiguration validationConfiguration) 
            : base(validationConfiguration)
        {
            Value(entry => entry.Title)
                .Trim()
                .IsNotNullOrEmpty()
                .HasMaxLength(300);

            Value(entry => entry.Description)
                .Trim()
                .IsNotNullOrEmpty();
        }

        #endregion
    }
}
