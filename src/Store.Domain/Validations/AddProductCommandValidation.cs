using FluentValidation;
using Store.Domain.Commands;

namespace Store.Domain.Validations
{
    public class AddProductCommandValidation : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidation()
        {
            RuleFor(c => c.ProductName)
                .NotEmpty().WithMessage("Please specify product name.")
                .Length(2, 100).WithMessage("Product name must be between 2 and 100 characters");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please specify product description.")
                .Length(2, 1000).WithMessage("Product name must be between 2 and 1000 characters");

            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("Please specify product price");
        }
    }
}