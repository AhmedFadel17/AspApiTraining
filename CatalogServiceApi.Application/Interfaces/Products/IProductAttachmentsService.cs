using CatalogServiceApi.Application.DTOs.ProductAttachments;

namespace CatalogServiceApi.Application.Interfaces.Products
{
    public interface IProductAttachmentsService
    {
        Task<ProductAttachmentsResponseDto> GetProductAttachments(int id);
        Task<bool> DeleteAsync(int id);
        Task<ProductAttachmentsResponseDto> CreateAsync(CreateProductAttachmentsDto dto);
        Task<List<ProductAttachmentsResponseDto>> GetAttachmentsByNameAsync(string name,int type);

    }
}
