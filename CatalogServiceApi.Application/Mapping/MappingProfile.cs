using AutoMapper;
using CatalogServiceApi.Application.DTOs.Categories;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Domain.Models;

namespace CatalogServiceApi.Application.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, CategotyResponseDto>();

            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, ProductResponseDto>();


        }
    }
}
