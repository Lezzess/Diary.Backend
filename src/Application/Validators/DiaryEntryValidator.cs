// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Common.Services.Validation;
using Common.Services.Validation.Configuration;
using Core.Models;

namespace Application.Validators
{
    internal class DiaryValidator : Validator<Diary>
    {
        public DiaryValidator(IValidationConfiguration validationConfiguration) 
            : base(validationConfiguration)
        {
            Value(entry => entry.Title)
                .IsNotEmpty()
                .HasMaxLength(300);

            Value(entry => entry.Description)
                .IsNotEmpty();
        }
    }
}
