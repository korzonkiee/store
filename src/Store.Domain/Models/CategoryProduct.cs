using System;

namespace Store.Domain.Models
{
    public class CategoryProduct
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public static CategoryProduct Create(Guid productId, Guid categoryId, Product product)
        {
            return new CategoryProduct()
            {
                ProductId = productId,
                CategoryId = categoryId,
                Product = product
            };
        }
    }
}