using System;
using MediatR;
using Store.Domain.Commands;
using Store.Domain.Models;
using Store.Domain.Repository;

namespace Store.Domain.CommandHandlers
{
    public class AddProductCommandHandler : INotificationHandler<AddProductCommand>
    {
        private readonly IProductsRepository productsRepository;

        public AddProductCommandHandler(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public void Handle(AddProductCommand command)
        {
            var product = Product.Create(
                Guid.Empty,
                command.Name,
                command.Description,
                command.Price,
                command.ImageUrl
            );

            productsRepository.Add(product);
        }
    }
}