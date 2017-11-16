using System.Linq;
using AutoMapper;
using Store.Domain.Models;
using Store.Infrastructure.DTOs;

namespace Store.Infrastructure.Automapper.Profiles
{
    public class CoreProfile : Profile
    {
        public CoreProfile()
        {
            CreateMap<Category, CategoryDTO>()
                .ForMember(
                    dto => dto.Products,
                    c => c.MapFrom(
                        x => x.CategoryProducts.Select(p => p.Product)
                    )
                );
            CreateMap<Product, ProductDTO>();                
        }
    }
}