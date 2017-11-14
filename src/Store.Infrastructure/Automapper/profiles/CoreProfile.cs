using AutoMapper;
using Store.Domain.Models;
using Store.Infrastructure.DTOs;

namespace Store.Infrastructure.Automapper.Profiles
{
    public class CoreProfile : Profile
    {
        public CoreProfile()
        {
            CreateMap<Product, ProductDTO>();
        }
    }
}