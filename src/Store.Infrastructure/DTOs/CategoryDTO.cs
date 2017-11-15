using System;

namespace Store.Infrastructure.DTOs
{
    public class CategoryDTO
    {
        public Guid Id { get; private set; }
        public DateTime DateCreated { get; private set; }
        public string Name { get; private set; }
    }
}