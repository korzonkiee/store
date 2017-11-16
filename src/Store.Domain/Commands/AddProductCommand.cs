using System;
using Store.Domain.Validations;

namespace Store.Domain.Commands
{
    public class AddProductCommand : Command
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public TimeSpan DeliveryTime { get; set; }
        public Guid? CategoryId { get; set; }

        public AddProductCommand(string name, string desc, decimal price,
            string imageUrl, TimeSpan deliveryTime, Guid? categoryId)
        {
            ProductName = name;
            Description = desc;
            Price = price;
            ImageUrl = imageUrl;
            DeliveryTime = deliveryTime;
            CategoryId = categoryId;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}