using CatalogServiceApi.Application.DTOs.Categories;

namespace CatalogServiceApi.Application.Interfaces.Categories
{
    public interface ICategoryServices
    {
        Task<CategotyResponseDto> GetByIdAsync(int id);
        Task<IEnumerable<CategotyResponseDto>> GetAllAsync();
        Task<CategotyResponseDto> CreateAsync(CreateCategoryDto dto);
        Task<CategotyResponseDto> UpdateAsync(int id, UpdateCategoryDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
