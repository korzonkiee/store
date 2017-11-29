using Store.Domain.Validations;

namespace Store.Domain.Commands
{
    public class RegisterUserCommand : Command
    {
        // public string FirstName { get; set; }
        // public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RegisterUserCommand(string email, string password)
        {
            // FirstName = firstName;
            // LastName = lastName;
            Email = email;
            Password = password;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}