using AutoMapper;
using CatalogServiceApi.Application.DTOs.Categories;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Domain.Models;
using CatalogServiceApi.Domain.MongoModels;

namespace CatalogServiceApi.Application.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateCategoryDto, Domain.Models.Category>();
            CreateMap<UpdateCategoryDto, Domain.Models.Category>();
            CreateMap<Domain.Models.Category, CategotyResponseDto>();

            CreateMap<CreateProductDto, Domain.Models.Product>();
            CreateMap<UpdateProductDto, Domain.Models.Product>();
            CreateMap<Domain.Models.Product, ProductResponseDto>();

            CreateMap<CreateCategoryDto, Domain.MongoModels.Category>();
            CreateMap<UpdateCategoryDto, Domain.MongoModels.Category>();
            CreateMap<Domain.MongoModels.Category, CategotyResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString())); 

            CreateMap<CreateProductDto, Domain.MongoModels.Product>();
            CreateMap<UpdateProductDto, Domain.MongoModels.Product>();
            CreateMap<Domain.MongoModels.Product, ProductResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}
