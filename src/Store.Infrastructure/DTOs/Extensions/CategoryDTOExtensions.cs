using System.Linq;
using Store.DataAccess;
using Store.Domain.Models;

namespace Store.Infrastructure.DTOs.Extensions
{
    public static class CategoryDTOExtensions
    {
        public static IQueryable<CategoryDTO> ProjectToCategoryDTO(this IQueryable<Category> categories, CoreDbContext context)
        {
            // var result = categories
            //     .Join(context.Products)
        }
    }
}