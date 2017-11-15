using Store.Domain.Models;

namespace Store.Domain.Repository
{
    public interface IProductsRepository : IRepository<Product>
    {
        // .. serach by name
    }
}