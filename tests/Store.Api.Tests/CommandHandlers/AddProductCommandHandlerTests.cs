using NSubstitute;
using Store.Domain.EventHandlers;
using Store.Domain.Repository;
using Store.Domain.CommandHandlers;
using Xunit;
using Store.Domain.Bus;
using Store.Domain.Commands;
using System;

namespace Store.Api.Tests.CommandHandlers
{
    public class AddProductCommandHandlerTests
    {
        [Fact]
        public void Test()
        {
            // // Arrange
            // var productsRepository = Substitute.For<IProductsRepository>();
            // var domainEventHandler = Substitute.For<DomainEventHandler>();
            // var bus = Substitute.For<IBus>();
            // var addProductCommand = new AddProductCommand("name", "desc", 5, "url", TimeSpan.MaxValue);
            // var AddProductCommandHandler = new AddProductCommandHandler(productsRepository, bus);

            // // Act
            // AddProductCommandHandler.Handle(addProductCommand);

            // // Assert
            // var events = domainEventHandler.GetEvents();
            // if (events != null)
            //     Console.WriteLine(events?.Count);
            // Console.WriteLine("Empty");
        }
    }
}