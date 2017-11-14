using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Store.Api.ControllerParams;
using Store.Domain.Repository;
using Store.Infrastructure.DTOs;

namespace Store.Api.Services
{
    public interface IProductsService
    {
        IEnumerable<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(Guid id);
        void AddProduct(ProductParams @params);
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

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var products = productsRepository.GetAll();
            return products.ProjectTo<ProductDTO>();
        }

        public ProductDTO GetProductById(Guid id)
        {
            var product = productsRepository.GetById(id);
            if (product != null)
                return mapper.Map<ProductDTO>(product);
            return null;
        }

        public void AddProduct(ProductParams @params)
        {
        }
    }
}