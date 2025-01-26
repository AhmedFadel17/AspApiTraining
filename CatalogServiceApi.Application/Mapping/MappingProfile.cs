using AutoMapper;
using CatalogServiceApi.Application.DTOs.Auth;
using CatalogServiceApi.Application.DTOs.Categories;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Domain.Models;

namespace CatalogServiceApi.Application.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, UserDto>();
            CreateMap<RegisterDto, User>();
            CreateMap<(string Token, User User), AuthResponseDto>()
                .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.Token))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));

            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, CategotyResponseDto>();

            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, ProductResponseDto>();


        }
    }
}
