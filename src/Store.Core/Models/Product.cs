using System;

namespace core.models
{
    public class Product
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public TimeSpan DeliveryTime { get; set; }

        public static Product Create(string name, string description,
            decimal price, string imageUrl, TimeSpan deliveryTime)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                Name = name,
                Description = description,
                Price = price,
                ImageUrl = imageUrl,
                DeliveryTime = deliveryTime
            };

            return product;
        }
    }
}