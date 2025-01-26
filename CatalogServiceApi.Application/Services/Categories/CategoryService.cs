using AutoMapper;
using CatalogServiceApi.Application.DTOs.Categories;
using CatalogServiceApi.Application.Interfaces.Categories;
using CatalogServiceApi.DataAccess.Repostories.Categories;
using CatalogServiceApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogServiceApi.Application.Services.Categories
{
    public class CategoryService : ICategoryServices
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repository,IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CategotyResponseDto> CreateAsync(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            var createdCategory = await _repository.CreateAsync(category);
            return _mapper.Map<CategotyResponseDto>(createdCategory);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null) throw new KeyNotFoundException("Category Not Found");
            _repository.Remove(category);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CategotyResponseDto>> GetAllAsync()
        {
            var categoriesQuery = _repository.GetAll();
            var categories = await categoriesQuery.ToListAsync();
            return _mapper.Map<IEnumerable<CategotyResponseDto>>(categories);
        }

        public async Task<CategotyResponseDto> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null) throw new KeyNotFoundException("Category Not Found");
            return _mapper.Map<CategotyResponseDto>(category);
        }

        public async Task<CategotyResponseDto> UpdateAsync(int id, UpdateCategoryDto dto)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null) throw new KeyNotFoundException("Category Not Found");
            var updatedCategory = _mapper.Map<Category>(dto);
            _repository.Update(updatedCategory);
            await _repository.SaveChangesAsync();
            return _mapper.Map<CategotyResponseDto>(updatedCategory);
        }
    }
}
