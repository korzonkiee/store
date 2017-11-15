using MediatR;
using Store.Domain.Events;

namespace Store.Api.Controllers
{
    public class CategoriesController : BaseApiController
    {
        public CategoriesController(INotificationHandler<DomainEvent> events) : base(events)
        {
        }
    }
}