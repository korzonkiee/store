using System;
using System.Collections.Generic;

namespace Store.Domain.Models
{
    public class Category
    {
        public Guid Id { get; private set; }
        public DateTime DateCreated { get; private set; }
        public string Name { get; private set; }
        public List<Product> Products;

        public static Category Create(string name)
        {
            return new Category()
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                Name = name,
                Products = new List<Product>()
            };
        }
    }
}