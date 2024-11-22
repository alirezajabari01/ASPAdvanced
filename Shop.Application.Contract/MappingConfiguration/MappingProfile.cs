using AutoMapper;
using Shop.Application.Contract.Dtos.Products;
using Shop.Model.Models;

namespace Shop.Application.Contract.MappingConfiguration
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Product, ProductAddDto>().ReverseMap();
        }
    }
}
