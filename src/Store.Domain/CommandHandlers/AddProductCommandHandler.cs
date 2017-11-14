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

        public void Handle(AddProductCommand notification)
        {
            var product = Product.Create(
                Guid.Empty,
                notification.Name,
                string.Empty,
                0,
                string.Empty
            );

            productsRepository.Add(product);
        }
    }
}