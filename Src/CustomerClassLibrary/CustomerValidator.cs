using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;

namespace CustomerClassLibrary
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName).MaximumLength(50).WithMessage("The maximum length of 'First Name' is 50 characters");
            RuleFor(customer => customer.LastName).MaximumLength(50).WithMessage("The maximum length of 'Last Name' is 50 characters");
            RuleFor(customer => customer.LastName).NotEmpty().WithMessage("Last Name is REQUIRED");
            RuleFor(customer => customer.AddressesList).NotNull().WithMessage("There must be at least 1 element in the 'AddressesList'");
            RuleFor(customer => customer.PhoneNumber).Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("The Phone Number must be in E.164 format");
            RuleFor(customer => customer.Email).EmailAddress().WithMessage("Wrong E-mail address");
            RuleFor(customer => customer.Notes).NotNull().WithMessage("There must be at least 1 element in the 'Notes'");
        }
        public List<string> RunCustomerValidator(Customer customer)
        {
            
            CustomerValidator validator = new CustomerValidator();
            ValidationResult results = validator.Validate(customer);
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
