using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections;
using Store.Api.Services;
using Store.Api.Controllers;
using Store.Infrastructure.DTOs;

namespace Store.Api.Tests.Controllers
{
    public class ProductsControllerTests
    {

        [Fact]
        public void GetAllProducts_Returns_Empty_List_When_Products_Not_Exist()
        {
            //Arrange
            var productsService = Substitute.For<IProductsService>();
            productsService.GetAllProducts().Returns(new List<ProductDTO>());

            var productsController = new ProductsController(productsService);

            //Act
            var result = productsController.GetProducts();

            //Assert
            Assert.True(result.GetType().IsAssignableFrom(typeof(OkObjectResult)));
            Assert.Equal(new List<ProductDTO>(), (result as OkObjectResult).Value);
        }

        [Fact]
        public void GetAllProducts_Returns_List_When_Products_Exist()
        {
            //Arrange
            var testProducts = GenerateProducts();
            var productsService = Substitute.For<IProductsService>();
            productsService.GetAllProducts().Returns(testProducts);

            var productsController = new ProductsController(productsService);

            //Act
            var result = productsController.GetProducts();

            //Assert
            Assert.True(result.GetType().IsAssignableFrom(typeof(OkObjectResult)));
            Assert.Equal(testProducts.Count, ((IList)(result as OkObjectResult).Value).Count);
        }

        private List<ProductDTO> GenerateProducts()
        {
            return new List<ProductDTO>()
            {
                new ProductDTO() { Name = "Product1" },
                new ProductDTO() { Name = "Product2" }
            };
        }
    }
}