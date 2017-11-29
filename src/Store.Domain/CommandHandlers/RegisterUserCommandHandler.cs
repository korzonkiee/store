using System.Threading.Tasks;
using MediatR;
using Store.Domain.Bus;
using Store.Domain.Commands;
using Store.Domain.Services;

namespace Store.Domain.CommandHandlers
{
    public class RegisterUserCommandHandler : CommandHandler,
        IAsyncNotificationHandler<RegisterUserCommand>
    {
        private readonly IRegisterUserService registerUserService;

        public RegisterUserCommandHandler(IBus bus, IRegisterUserService registerUserService) : base(bus)
        {
            this.registerUserService = registerUserService;
        }

        public async Task Handle(RegisterUserCommand command)
        {
            if (!command.IsValid())
            {
                RaiseValidationErrors(command);
                return;
            }

            var result = await registerUserService.Register(command.Email, command.Password);

            if (!result)
            {
                RaiseValidationError(command.MessageType, "Could not register user");
            }
        }
    }
}