using MediatR;
using Store.Domain.Bus;
using Store.Domain.Commands;
using Store.Domain.Models;
using Store.Domain.Repository;

namespace Store.Domain.CommandHandlers
{
    public class AddCategoryCommandHandler : CommandHandler,
        INotificationHandler<AddCategoryCommand>
    {
        private readonly ICategoriesRepository categoriesRepository;
        public AddCategoryCommandHandler(ICategoriesRepository categoriesRepository, IBus bus) : base(bus)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public void Handle(AddCategoryCommand command)
        {
            if (!command.IsValid())
            {
                RaiseValidationErrors(command);
                return;
            }

            var category = Category.Create(command.Name);

            categoriesRepository.Add(category);
        }
    }
}