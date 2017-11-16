using Store.Domain.Validations;

namespace Store.Domain.Commands
{
    public class AddCategoryCommand : Command
    {
        public string Name { get; set; }

        public AddCategoryCommand(string name)
        {
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}