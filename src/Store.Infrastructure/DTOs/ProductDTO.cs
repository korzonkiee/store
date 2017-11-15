using System;

namespace Store.Infrastructure.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; private set; }
        public DateTime DateCreated { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string ImageUrl { get; private set; }
    }
}