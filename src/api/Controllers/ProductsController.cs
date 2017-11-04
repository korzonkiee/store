using System;
using System.Collections.Generic;
using core.dtos;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(ProductsRepository.GetProducts());
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = ProductsRepository.GetProductById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
    }
}