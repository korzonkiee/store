using AutoMapper;
using Store.Core.DTOs;
using Store.Core.Models;

namespace Store.Core.Automapper.Profiles
{
    public class CoreProfile : Profile
    {
        public CoreProfile()
        {
            CreateMap<Product, ProductDTO>();
        }
    }
}