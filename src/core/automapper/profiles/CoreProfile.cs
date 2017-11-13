using AutoMapper;
using core.dtos;
using core.models;

namespace core.automapper.profiles
{
    public class CoreProfile : Profile
    {
        public CoreProfile()
        {
            CreateMap<Product, ProductDTO>();
        }
    }
}