using CatalogServiceApi.Application.DTOs.Categories;

namespace CatalogServiceApi.Application.Interfaces.Categories
{
    public interface ICategoryService
    {
        Task<CategoryResponseDto> GetByIdAsync(int id);
        Task<List<CategoryResponseDto>> GetAllAsync();
        Task<CategoryResponseDto> CreateAsync(CreateCategoryDto dto);
        Task<CategoryResponseDto> UpdateAsync(int id, UpdateCategoryDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
