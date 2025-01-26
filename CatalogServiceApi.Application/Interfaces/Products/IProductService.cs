using CatalogServiceApi.Application.DTOs.Products;

namespace CatalogServiceApi.Application.Interfaces.Products
{
    internal interface IProductService
    {
        Task<ProducResponseDto> GetByIdAsync(int id);
        Task<ProducResponseDto> GetByNameAsync(string name);
        Task<IEnumerable<ProducResponseDto>> GetAllAsync();
        Task<ProducResponseDto> CreateAsync(CreateProductDto dto);
        Task<ProducResponseDto> UpdateAsync(int id, UpdateProductDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
