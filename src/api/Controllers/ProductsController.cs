using System;
using System.Collections.Generic;
using System.Net;
using api.ControllerParams;
using core.commands;
using core.dtos;
using core.models;
using core.respositories;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(productsRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            var product = productsRepository.FindById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductParams @params)
        {
            if (@params == null)
            {
                return BadRequest();
            }

            var product = Product.Create(@params.Name);
            productsRepository.Add(product);

            return new StatusCodeResult((int) HttpStatusCode.Created);
        }
    }
}