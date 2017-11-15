using System.Collections.Generic;
using MediatR;
using Store.Domain.Events;

namespace Store.Domain.EventHandlers
{
    public class DomainEventHandler : INotificationHandler<DomainEvent>
    {
        private List<DomainEvent> events;

        public DomainEventHandler()
        {
            this.events = new List<DomainEvent>();
        }
        
        public void Handle(DomainEvent @event)
        {
            events.Add(@event);
        }

        public bool HasEvents()
        {
            return events.Count > 0;
        }

        public List<DomainEvent> GetEvents()
        {
            return events;
        }
    }
}