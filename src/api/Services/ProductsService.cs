using System.Collections.Generic;
using System.Linq;
using core.dtos;
using core.respositories;

namespace api.Services
{
    public interface IProductsService
    {
        List<ProductDTO> GetAllProducts();
    }
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository productsRepository;
        public ProductsService(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public List<ProductDTO> GetAllProducts()
        {
            return productsRepository
                .GetAll()
                .Select(p => new ProductDTO()
                {
                    Name = p.Name
                })
                .ToList();
        }
    }
}