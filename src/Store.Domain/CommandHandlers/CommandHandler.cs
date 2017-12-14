using MediatR;
using Store.Domain.Bus;
using Store.Domain.Commands;
using Store.Domain.Events;

namespace Store.Domain.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IBus bus;

        public CommandHandler(IBus bus)
        {
            this.bus = bus;
        }
        
        protected void RaiseValidationErrors(Command command)
        {
            foreach (var error in command.ValidationResult.Errors)
            {
                RaiseValidationError(command.MessageType, error.ErrorMessage);
            }
        }

        protected void RaiseValidationError(string errorType, string error)
        {
            bus.RaiseEvent(new DomainEvent(errorType, error));
        }
    }
}