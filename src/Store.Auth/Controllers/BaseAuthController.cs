using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.EventHandlers;
using Store.Domain.Events;

namespace Store.Auth.Controllers
{
    public abstract class BaseAuthController : ControllerBase
    {
        private readonly DomainEventHandler events;

        public BaseAuthController(INotificationHandler<DomainEvent> events)
        {
            this.events = (DomainEventHandler)events;
        }

        protected bool IsOperationsValid()
        {
            return !events.HasEvents();
        }

        protected IActionResult ActionResponse(object result = null)
        {
            if (IsOperationsValid())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    errors = events.GetEvents().Select(e => e.EventError)
                });
            }
        }
    }
}