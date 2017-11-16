using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Store.Api.ControllerParams;
using Store.Domain.Bus;
using Store.Domain.Commands;
using Store.Domain.Models;
using Store.Domain.Repository;
using Store.Infrastructure.DTOs;

namespace Store.Api.Services
{
    public interface IProductsService
    {
        IEnumerable<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(Guid id);
        void AddProduct(ProductParams @params);

        IEnumerable<ProductDTO> GetPorductsByName(string keyValue);
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

        public IEnumerable<ProductDTO> GetPorductsByName(string keyValue)
        {
            var products = productsRepository.GetPorductsByName(keyValue);
            return products.ProjectTo<ProductDTO>();
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
            var addProductCommand = new AddProductCommand(
                @params.Name,
                @params.Description,
                @params.Price,
                @params.ImageUrl,
                @params.DeliveryTime);
                
            bus.SendCommand(addProductCommand);
        }
    }
}