using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Api.ControllerParams;
using Store.Api.Services;
using Store.Domain.Events;

namespace Store.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CategoriesController : BaseApiController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService, INotificationHandler<DomainEvent> events) : base(events)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(categoriesService.GetAllCategories());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryParams @params)
        {
            categoriesService.AddCategory(@params);
            return ActionResponse(@params);
        }
    }
}