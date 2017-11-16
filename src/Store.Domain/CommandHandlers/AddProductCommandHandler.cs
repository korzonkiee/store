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
        private readonly ICategoriesRepository categoriesRepository;
        private readonly IBus bus;

        public AddProductCommandHandler(IProductsRepository productsRepository,
            ICategoriesRepository categoriesRepository, IBus bus) : base(bus)
        {
            this.categoriesRepository = categoriesRepository;
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
                command.CategoryId,
                command.ProductName,
                command.Description,
                command.Price,
                command.ImageUrl
            );

            if (product.CategoryId.HasValue)
            {
                var categoryProduct = CategoryProduct.Create(
                    product.Id,
                    product.CategoryId.Value,
                    product
                );
                categoriesRepository.AddCategoryProduct(categoryProduct);
            }

            productsRepository.Add(product);
        }
    }
}