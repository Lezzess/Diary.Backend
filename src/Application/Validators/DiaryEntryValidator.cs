// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Core.Models;
using Utilities.Services.Validation;
using Utilities.Services.Validation.Configuration;

namespace Application.Validators
{
    internal class DiaryValidator : Validator<Diary>
    {
        #region Constructor

        public DiaryValidator(IValidationConfiguration validationConfiguration) 
            : base(validationConfiguration)
        {
            Value(entry => entry.Id)
                .IsNotNullOrEmpty();

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
