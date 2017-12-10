using FluentValidation;
using Store.Domain.Commands;

namespace Store.Domain.Validations
{
    public class RegisterUserCommandValidation : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidation()
        {
            RuleFor(c => c.Email)
                .NotNull().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Email is invalid.")
                .Length(1, 256).WithMessage("Email length mu be between 1 and 256");

            // RuleFor(c => c.FirstName)
            //     .NotEmpty().WithMessage("First name cannot be empty.")
            //     .Length(2, 100).WithMessage("First name must be between 2 and 100 characters");                

            // RuleFor(c => c.LastName)
            //     .NotEmpty().WithMessage("Last name cannot be empty.")
            //     .Length(2, 100).WithMessage("Last name must be between 2 and 100 characters");                

            RuleFor(c => c.Password)
                .Length(8, 100).WithMessage("Password is too short");
        }
    }
}