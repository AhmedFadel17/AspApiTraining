using AutoMapper;
using CatalogServiceApi.Application.DTOs.Categories;
using CatalogServiceApi.Application.DTOs.ProductAttachments;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Domain.Enums;
using CatalogServiceApi.Domain.Models;


namespace CatalogServiceApi.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, CategoryResponseDto>();

            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, ProductResponseDto>();

            CreateMap<ProductBrandAttachmentsDto, ProductAttachment>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.BrandName))
            .ForMember(dest => dest.BrandDescription, opt => opt.MapFrom(src => src.BrandDescription))
            .ForMember(dest => dest.BrandPhone, opt => opt.MapFrom(src => src.BrandPhone));

            // Discount mapping
            CreateMap<ProductDiscountAttachmentsDto, ProductAttachment>()
                .ForMember(dest => dest.DiscountAmount, opt => opt.MapFrom(src => src.DiscountAmount))
                .ForMember(dest => dest.DiscountPercentage, opt => opt.MapFrom(src => src.DiscountPercentage))
                .ForMember(dest => dest.ExpiryDate, opt => opt.MapFrom(src => src.ExpiryDate));

            // Media mapping
            CreateMap<ProductMediaAttachmentsDto, ProductAttachment>()
                .ForMember(dest => dest.MediaUrl, opt => opt.MapFrom(src => src.MediaUrl))
                .ForMember(dest => dest.MediaType, opt => opt.MapFrom(src => src.MediaType));

            // Custom mapping to merge all three DTOs into ProductAttachment
            CreateMap<(int productId,ProductBrandAttachmentsDto? brand, ProductDiscountAttachmentsDto? discount, ProductMediaAttachmentsDto? media), ProductAttachment>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.productId)) // Default to 0 if all are null
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.brand != null ? src.brand.BrandName : null))
                .ForMember(dest => dest.BrandDescription, opt => opt.MapFrom(src => src.brand != null ? src.brand.BrandDescription : null))
                .ForMember(dest => dest.BrandPhone, opt => opt.MapFrom(src => src.brand != null ? src.brand.BrandPhone : null))
                .ForMember(dest => dest.DiscountAmount, opt => opt.MapFrom(src => src.discount != null ? src.discount.DiscountAmount : null))
                .ForMember(dest => dest.DiscountPercentage, opt => opt.MapFrom(src => src.discount != null ? src.discount.DiscountPercentage : null))
                .ForMember(dest => dest.ExpiryDate, opt => opt.MapFrom(src => src.discount.ExpiryDate))
                .ForMember(dest => dest.MediaUrl, opt => opt.MapFrom(src => src.media != null ? src.media.MediaUrl : null))
                .ForMember(dest => dest.MediaType, opt => opt.MapFrom(src => src.media != null ? src.media.MediaType : null));
        

        CreateMap<ProductAttachment, ProductAttachmentsResponseDto>();

        }
    }
}
