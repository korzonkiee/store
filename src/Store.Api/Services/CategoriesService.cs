using System;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
using Store.Api.ControllerParams;
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

        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            var categories = categoriesRepository.GetAll();
            return categories.ProjectTo<CategoryDTO>(categories);
        }

        public CategoryDTO GetCategoryById(Guid id)
        {
            
        }
        
        public void AddCategory(CategoryParams @params)
        {
            
        }
    }
}