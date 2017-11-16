using System;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
using Store.Api.ControllerParams;
using Store.Domain.Bus;
using Store.Domain.Commands;
using Store.Domain.Repository;
using Store.Infrastructure.DTOs;

namespace Store.Api.Services
{
    public interface ICategoriesService
    {
        IEnumerable<CategoryDTO> GetAllCategories();
        CategoryDTO GetCategoryById(Guid id);
        void AddCategory(CategoryParams @params);
    }

    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository categoriesRepository;
        private readonly IBus bus;

        public CategoriesService(ICategoriesRepository categoriesRepository,
            IBus bus)
        {
            this.categoriesRepository = categoriesRepository;
            this.bus = bus;
        }

        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            var categories = categoriesRepository.GetAll();
            var mappedCategories = categories.ProjectTo<CategoryDTO>(categories);
            return mappedCategories;
        }

        public CategoryDTO GetCategoryById(Guid id)
        {
            return null;
        }

        public void AddCategory(CategoryParams @params)
        {
            var addProductCommand = new AddCategoryCommand(
                @params.Name);

            bus.SendCommand(addProductCommand);
        }
    }
}