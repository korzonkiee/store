using System.Threading.Tasks;
using MediatR;
using Store.Domain.Commands;
using Store.Domain.Events;
using Store.Domain.Messages;

namespace Store.Infrastructure.Bus
{
    public sealed class InMemoryBus : IBus
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return Publish(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            // if (!@event.MessageType.Equals("DomainNotification"))
            //     _eventStore?.Save(@event);

            return Publish(@event);
        }

        private Task Publish<T>(T message) where T : Message
        {
            return _mediator.Publish(message);
        }
    }
}