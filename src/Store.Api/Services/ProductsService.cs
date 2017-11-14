using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Store.Api.ControllerParams;
using Store.Domain.Commands;
using Store.Domain.Models;
using Store.Domain.Repository;
using Store.Infrastructure.Bus;
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
        private readonly IBus bus;

        public ProductsService(IProductsRepository productsRepository,
            IBus bus, IMapper mapper)
        {
            this.productsRepository = productsRepository;
            this.mapper = mapper;
            this.bus = bus;
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            //var products = productsRepository.GetAll();
            var products = new List<Product>();
            //return products.ProjectTo<ProductDTO>();
            return mapper.Map<List<ProductDTO>>(products);
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
            var addProductCommand = new AddProductCommand(@params.Name);
            bus.SendCommand(addProductCommand);
        }
    }
}