using System;
using MediatR;
using Store.Domain.Bus;
using Store.Domain.Commands;
using Store.Domain.Models;
using Store.Domain.Repository;

namespace Store.Domain.CommandHandlers
{
    public class AddProductCommandHandler : CommandHandler,
        INotificationHandler<AddProductCommand>
    {
        private readonly IProductsRepository productsRepository;
        private readonly IBus bus;

        public AddProductCommandHandler(IProductsRepository productsRepository,
            IBus bus) : base(bus)
        {
            this.productsRepository = productsRepository;
            this.bus = bus;
        }

        public void Handle(AddProductCommand command)
        {
            if (!command.IsValid())
            {
                RaiseValidationErrors(command);
                return;
            }

            var product = Product.Create(
                Guid.Empty,
                command.ProductName,
                command.Description,
                command.Price,
                command.ImageUrl
            );

            productsRepository.Add(product);
        }
    }
}