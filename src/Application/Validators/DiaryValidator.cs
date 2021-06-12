// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Core.Models;
using FluentValidation;

namespace Application.Validators
{
    internal class DiaryValidator : AbstractValidator<Diary>
    {
        public DiaryValidator()
        {
            RuleFor(diary => diary.Title)
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(diary => diary.Description)
                .NotEmpty();
        }
    }
}
