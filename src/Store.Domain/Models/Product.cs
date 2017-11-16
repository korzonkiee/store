using System;

namespace Store.Domain.Models
{
    public class Product
    {
        public Guid Id { get; private set; }
        public Guid? CategoryId { get; private set; }
        public DateTime DateCreated { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string ImageUrl { get; private set; }
        

        public static Product Create(Guid? categoryId, string name, string description,
            decimal price, string imageUrl)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                CategoryId = categoryId,
                DateCreated = DateTime.Now,
                Name = name,
                Description = description,
                Price = price,
                ImageUrl = imageUrl
            };

            return product;
        }
    }
}