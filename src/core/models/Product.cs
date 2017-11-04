using System;

namespace core.models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static Product Create(string name)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            return product;
        }
    }
}