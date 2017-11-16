using System;
using System.Collections.Generic;

namespace Store.Domain.Models
{
    public class Category
    {
        public Guid Id { get; private set; }
        public DateTime DateCreated { get; private set; }
        public string Name { get; private set; }
        private readonly List<CategoryProduct> categoryProducts = new List<CategoryProduct>();
        public IReadOnlyList<CategoryProduct> CategoryProducts => categoryProducts;

        public static Category Create(string name)
        {
            return new Category()
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                Name = name
            };
        }

        public void AddCategoryProduct(CategoryProduct categoryProduct)
        {
            categoryProducts.Add(categoryProduct);
        }
    }
}