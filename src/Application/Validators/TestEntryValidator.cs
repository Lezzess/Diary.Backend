using Core.Models;
using CoreServices.Services.Validation.Configuration;
using CoreServices.Services.Validation.Validators;

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
                .IsNotNull()
                .IsNotEmpty()
                .HasMinLength(3)
                .HasMaxLength(5);

            Value(entry => entry.PropertyTwo)
                .IsNotNull()
                .IsInRange(2, 5);

            Value(entry => entry.PropertyThree)
                .Trim()
                .IsNotNull()
                .IsNotEmpty()
                .HasMinLength(1)
                .HasMaxLength(2);
        }

        #endregion
    }
}
