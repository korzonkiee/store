using FluentValidation;
using Store.Domain.Commands;

namespace Store.Domain.Validations
{
    public class AddCategoryCommandValidation : AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryCommandValidation()
        {   
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please specify category name.")
                .Length(2, 100).WithMessage("Product name must be between 2 and 100 characters");                
        }   
    }
}