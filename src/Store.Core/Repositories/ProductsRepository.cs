using System;
using System.Collections.Generic;
using System.Linq;
using Store.Core.Models;

namespace Store.Core.Respositories
{
    public interface IProductsRepository
    {
         IEnumerable<Product> GetAll();
         Product FindById(Guid id);

         void Add(Product product);
    }

    public class ProductsRepository : IProductsRepository
    {
        private readonly CoreDbContext context;
        public ProductsRepository(CoreDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products.ToList();
        }
        
        public Product FindById(Guid id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            context.Add(product);
            context.SaveChanges();
        }
    }
}