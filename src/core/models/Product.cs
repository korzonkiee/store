using System;

namespace core.models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateCreated { get; set; }

        public static Product Create(string name, string description, string imageUrl)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = name,
                ImageUrl = imageUrl,
                Description = description,
                DateCreated = DateTime.Now
            };

            return product;
        }
    }
}