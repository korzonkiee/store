using System;
using System.Linq;
using Store.Domain.Models;
using Store.Domain.Repository;

namespace Store.DataAccess.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly CoreDbContext context;
        public ProductsRepository(CoreDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Product> GetAll()
        {
            return context.Products;
        }
        
        public Product GetById(Guid id)
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