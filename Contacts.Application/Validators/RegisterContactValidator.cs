using Contacts.Domain.Entities;
using FluentValidation;

namespace Contacts.Application.Validators
{
    public class RegisterContactValidator : AbstractValidator<Contact>
    {
        public RegisterContactValidator()
        {
            RuleFor(i => i.Email.Endereco)
                .NotEmpty().WithMessage("Email is required.")
                .NotNull().WithMessage("Email cannot be null.")
                .EmailAddress().WithMessage("Email format is invalid.");

            RuleFor(i => i.Phone.DDD)
                .NotEmpty().WithMessage("DDD is required.")
                .NotNull().WithMessage("DDD cannot be null.")
                .InclusiveBetween(11, 99).WithMessage("DDD must be a valid 2-digit number.");

            RuleFor(i => i.Phone.Number)
                .NotEmpty().WithMessage("Phone number is required.")
                .NotNull().WithMessage("Phone number cannot be null.")
                .InclusiveBetween(10000000, 999999999).WithMessage("Phone number must be between 8 and 9 digits.");

            RuleFor(i => i.Name.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .NotNull().WithMessage("First name cannot be null.")
                .MinimumLength(2).WithMessage("First name must be at least 2 characters long.")
                .Matches("^[a-zA-Z]+$").WithMessage("First name must contain only letters.");

            RuleFor(i => i.Name.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .NotNull().WithMessage("Last name cannot be null.")
                .MinimumLength(2).WithMessage("Last name must be at least 2 characters long.")
                .Matches("^[a-zA-Z]+$").WithMessage("Last name must contain only letters.");
        }
    }
}
