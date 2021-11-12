using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;

namespace CustomerClassLibrary
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.AddressLine).NotEmpty().WithMessage("Address Line is REQUIRED");
            RuleFor(address => address.AddressLine).MaximumLength(100).WithMessage("The maximum length of 'Address Line' is 100 characters");
            RuleFor(address => address.AddressLine2).MaximumLength(100).WithMessage("The maximum length of 'Address Line 2' is 100 characters");
            RuleFor(address => address.City).NotEmpty().WithMessage("City is REQUIRED");
            RuleFor(address => address.City).MaximumLength(50).WithMessage("The maximum length of 'City' is 50 characters");
            RuleFor(address => address.PostalCode).NotEmpty().WithMessage("Postal Code is REQUIRED");
            RuleFor(address => address.PostalCode).MaximumLength(6).WithMessage("The maximum length of 'Postal Code' is 6 characters");
            RuleFor(address => address.State).NotEmpty().WithMessage("State is REQUIRED");
            RuleFor(address => address.State).MaximumLength(20).WithMessage("The maximum length of 'State' is 20 characters");
            RuleFor(address => address.Country).NotEmpty().WithMessage("Country is REQUIRED");
            List<string> conditions = new List<string>() { "canada", "united States" };
            RuleFor(x => x.Country)
              .Must(x => conditions.Contains(x.ToLower())).When(address => address.Country != null && address.Country != string.Empty)
              .WithMessage("Country should be 'Unated States' or 'Canada'");
        }
        public List<string> RunAddressValidator(Address address)
        {

            AddressValidator validator = new AddressValidator();
            ValidationResult results = validator.Validate(address);
            List<string> message = new();
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    message.Add(failure.ErrorMessage);
                }
            }
            return message;
        }
    }
}
