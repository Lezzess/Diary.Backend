using Core.Models;
using Utilities.Services.Validation;
using Utilities.Services.Validation.Configuration;

namespace Application.Validators
{
    internal class TestEntryValidator : Validator<TestEntry>
    {
        #region Constructor

        public TestEntryValidator(IValidationConfiguration validationConfiguration) 
            : base(validationConfiguration)
        {
            Value(entry => entry.PropertyOne)
                .Trim()
                .IsNotNullOrEmpty()
                .HasMinLength(3)
                .HasMaxLength(5);

            Value(entry => entry.PropertyTwo)
                .IsNotNull()
                .IsInRange(2, 5);

            Value(entry => entry.PropertyThree)
                .Trim()
                .IsNotNullOrEmpty()
                .HasMinLength(1)
                .HasMaxLength(2);
        }

        #endregion
    }
}
