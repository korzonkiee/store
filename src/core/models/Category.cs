using System;
using System.Collections.Generic;

namespace core.models
{
    public class Category
    {
        public Guid Id { get; private set; }
        public DateTime DateCreated { get; private set; }
        public string Name { get; private set; }

        public static Category Create(string name)
        {
            return new Category()
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                Name = name
            };
        }
    }
}