using AutoMapper;
using CatalogServiceApi.Application.DTOs.ProductAttachments;
using CatalogServiceApi.Application.Interfaces.Products;
using CatalogServiceApi.Application.Providers;
using CatalogServiceApi.DataAccess.Repostories.ProductAttachments;
using CatalogServiceApi.Domain.Enums;
using CatalogServiceApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CatalogServiceApi.Application.Services.Products
{
    public class ProductAttachmentsService : IProductAttachmentsService
    {
        private readonly IExternalServiceProvider _provider;
        private readonly IProductAttachmentsRepository _repository;
        private readonly IMapper _mapper;

        public ProductAttachmentsService(IExternalServiceProvider provider,  IProductAttachmentsRepository repository,IMapper mapper)
        {
            _provider=provider;
            _mapper= mapper;
            _repository = repository;
        }

        public async Task<ProductAttachmentsResponseDto> GetProductAttachments(int productId)
        {
            var attachmentTypes = new List<AttachmentsType>
            {
                AttachmentsType.Brand,
                AttachmentsType.Discount,
                AttachmentsType.Media
            };

            var tasks = new List<Task<ProductAttachmentDto>>();

            foreach (var type in attachmentTypes)
            {
                tasks.Add(_provider.FetchAttachmentAsync(productId, type));
            }

            var results = await Task.WhenAll(tasks);
            var brandDto = results.FirstOrDefault(r => r.AttachmentType == AttachmentsType.Brand) as ProductBrandAttachmentsDto;
            var discountDto = results.FirstOrDefault(r => r.AttachmentType == AttachmentsType.Discount) as ProductDiscountAttachmentsDto;
            var mediaDto = results.FirstOrDefault(r => r.AttachmentType == AttachmentsType.Media) as ProductMediaAttachmentsDto;

            var attachment = _mapper.Map<ProductAttachment>((productId,brandDto, discountDto, mediaDto));

            var createdAttachment = await _repository.CreateAsync(attachment);
            return _mapper.Map<ProductAttachmentsResponseDto>(createdAttachment);
        }

        public async Task<ProductAttachmentsResponseDto> CreateAsync(CreateProductAttachmentsDto dto)
        {
            var product = _mapper.Map<ProductAttachment>(dto);
            var createdProduct = await _repository.CreateAsync(product);
            return _mapper.Map<ProductAttachmentsResponseDto>(createdProduct);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var productAtt = await _repository.GetByIdAsync(id);
            if (productAtt == null) throw new KeyNotFoundException("Product Attachments Not Found");
            _repository.Remove(productAtt);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProductAttachmentsResponseDto>> GetAttachmentsByNameAsync(string name,int type)
        {

            var attachments = type switch
            {
                0 => await _repository.GetByBrandNameLinqAsync(name),
                1 => await _repository.GetByBrandNameDLinqAsync(name),
                2 => await _repository.GetByBrandNameDEAsync(name),
                3 => await _repository.GetByBrandNameEMAsync(name),
                _ => throw new InvalidOperationException("Unknown type")
            };
            return _mapper.Map<List<ProductAttachmentsResponseDto>>(attachments);
        }

        public async Task<ProductAttachmentsResponseDto> GetByIdAsync(int id)
        {
            var attachment = await _repository.GetByIdWithProductAsync(id);
            if (attachment == null) throw new KeyNotFoundException("Attachment Not Found");
            return _mapper.Map<ProductAttachmentsResponseDto>(attachment);
        }

        public async Task<List<ProductAttachmentsResponseDto>> GetAllWithFiltersAsync(string name, string productName, decimal minProductPrice, int minDiscount, string categoryName)
        {
            var attachments = await _repository.GetAllWithFiltersAsync(name,productName,minProductPrice,minDiscount,categoryName);
            return _mapper.Map<List<ProductAttachmentsResponseDto>>(attachments);
        }

        public async Task<int> BulkDeleteByNameAsync(AttachmentsBulkDeleteDto dto)
        {
            return await _repository.BulkDeleteAsync(x => x.BrandName.Contains(dto.Name));           
        }

        public async Task<int> BulkUpdateNameAsync(AttachmentsBulkUpdateDto dto)
        {
            return await _repository.BulkUpdateAsync(x => x.BrandName.Contains(dto.Name), attch => attch
            .SetProperty(p => p.BrandName , dto.NewName)
            .SetProperty(p => p.BrandDescription, "New desc by M.Fadel"));           
           
        }
    }
}
