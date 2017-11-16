using System;
using System.Linq;
using Store.Domain.Models;
using Store.Domain.Repository;
using System.Data.SqlClient;

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

        public IQueryable<Product> GetProductsByName(string keyValue){
            return context.Products.Where(s => s.Name.Contains(keyValue));
        }

        public void Add(Product product)
        {
            context.Add(product);
            context.SaveChanges();
        }
    }
}