using System;
using System.Linq;
using Store.Domain.Models;
using Store.Domain.Repository;

namespace Store.DataAccess.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly CoreDbContext context;

        public CategoriesRepository(CoreDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Category> GetAll()
        {
            return context.Categories;
        }

        public Category GetById(Guid id)
        {
            return context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void AddCategoryProduct(CategoryProduct categoryProduct)
        {
            var category = context.Categories
                .Where(c => c.Id == categoryProduct.CategoryId)
                .FirstOrDefault();

            if (category != null)
            {
                category.AddCategoryProduct(categoryProduct);
            }
        }

        public void Add(Category entity)
        {
            context.Categories.Add(entity);
            context.SaveChanges();
        }
    }
}