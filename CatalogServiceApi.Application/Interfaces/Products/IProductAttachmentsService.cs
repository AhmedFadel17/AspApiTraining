using CatalogServiceApi.Application.DTOs.ProductAttachments;

namespace CatalogServiceApi.Application.Interfaces.Products
{
    public interface IProductAttachmentsService
    {
        Task<ProductAttachmentsResponseDto> GetProductAttachments(int id);
        Task<bool> DeleteAsync(int id);
        Task<ProductAttachmentsResponseDto> CreateAsync(CreateProductAttachmentsDto dto);
        Task<ProductAttachmentsResponseDto> GetByIdAsync(int id);
        Task<List<ProductAttachmentsResponseDto>> GetAttachmentsByNameAsync(string name,int type);
        Task<List<ProductAttachmentsResponseDto>> GetAllWithFiltersAsync(string name, string productName, decimal minProductPrice, int minDiscount, string categoryName);
        Task<int> BulkDeleteByNameAsync(AttachmentsBulkDeleteDto dto);
        Task<int> BulkUpdateNameAsync(AttachmentsBulkUpdateDto dto);

    }
}
