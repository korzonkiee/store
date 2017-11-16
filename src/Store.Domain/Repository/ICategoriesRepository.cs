using Store.Domain.Models;

namespace Store.Domain.Repository
{
    public interface ICategoriesRepository : IRepository<Category>
    {
         void AddCategoryProduct(CategoryProduct categoryProduct);
    }
}