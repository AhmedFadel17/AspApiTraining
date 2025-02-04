using CatalogServiceApi.Application.DTOs.Products;

namespace CatalogServiceApi.Application.Interfaces.Products
{
    public interface IProductService
    {
        Task<ProductResponseDto> GetByIdAsync(int id);
        Task<ProductResponseDto> GetByNameAsync(string name);
        Task<IEnumerable<ProductResponseDto>> GetByPriceAsync(decimal minFrom, decimal maxFrom, decimal minTo, decimal maxTo);
        Task<IEnumerable<ProductResponseDto>> GetAllAsync();
        Task<ProductResponseDto> CreateAsync(CreateProductDto dto);
        Task<ProductResponseDto> UpdateAsync(int id, UpdateProductDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
