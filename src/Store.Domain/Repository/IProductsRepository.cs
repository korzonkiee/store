using System.Linq;
using Store.Domain.Models;

namespace Store.Domain.Repository
{
    public interface IProductsRepository : IRepository<Product>
    {
        IQueryable<Product> GetPorductsByName(string keyValue);
    }
}