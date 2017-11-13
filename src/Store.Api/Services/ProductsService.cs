using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
        private readonly IMapper mapper;

        public ProductsService(IProductsRepository productsRepository, IMapper mapper)
        {
            this.productsRepository = productsRepository;
            this.mapper = mapper;
        }

        public List<ProductDTO> GetAllProducts()
        {
            var products = productsRepository.GetAll();
            return mapper.Map<List<ProductDTO>>(products);
        }
    }
}