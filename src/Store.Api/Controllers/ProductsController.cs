using System;
using System.Collections.Generic;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Api.ControllerParams;
using Store.Api.Services;
using Store.Domain.Events;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService, INotificationHandler<DomainEvent> events)
            : base(events)
        {
            this.productsService = productsService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(productsService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            var product = productsService.GetProductById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductParams @params)
        {
            productsService.AddProduct(@params);
            return ActionResponse(@params);
        }
    }
}