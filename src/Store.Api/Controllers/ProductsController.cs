using System;
using System.Collections.Generic;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using Store.Api.ControllerParams;
using Store.Api.Services;
using Store.Domain.Events;
using Store.Domain.Models;
using Store.Infrastructure.DTOs;

namespace Store.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService, INotificationHandler<DomainEvent> events)
            : base(events)
        {
            this.productsService = productsService;
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(productsService.GetAllProducts());
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            var product = productsService.GetProductById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [AllowAnonymous]
        [HttpGet("search/{keyword}")]
        public IActionResult SearchForProductsByName(string keyword)
        {
            var products = productsService.GetProductsByName(keyword);
            if (products == null)
                return NotFound();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductParams @params)
        {
            productsService.AddProduct(@params);
            return ActionResponse(@params);
        }
    }
}