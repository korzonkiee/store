using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Services;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(productsService.GetAllProducts());
        }

        // [HttpGet("{id}")]
        // public IActionResult GetProductById(Guid id)
        // {
        //     var product = productsService.FindById(id);
        //     if (product == null)
        //         return NotFound();
        //     return Ok(product);
        // }

        // [HttpPost]
        // public IActionResult Create([FromBody] ProductParams @params)
        // {
        //     if (@params == null)
        //     {
        //         return BadRequest();
        //     }

        //     var product = Product.Create(
        //         @params.Name,
        //         @params.Description,
        //         @params.Price,
        //         @params.ImageUrl,
        //         @params.DeliveryTime
        //     );
            
        //     productsRepository.Add(product);

        //     return new StatusCodeResult((int) HttpStatusCode.Created);
        // }
    }
}