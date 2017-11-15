using System;

namespace Store.Domain.Commands
{
    public class AddProductCommand : Command
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public TimeSpan DeliveryTime { get; set; }

        public AddProductCommand(string name, string desc, decimal price,
            string imageUrl, TimeSpan deliveryTime)
        {
            Name = name;
            Description = desc;
            Price = price;
            ImageUrl = imageUrl;
            DeliveryTime = deliveryTime;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}