using AutoMapper;
using CatalogServiceApi.Application.DTOs.Categories;
using CatalogServiceApi.Application.Interfaces.Categories;
using CatalogServiceApi.MongoDbAccess.Repostories.Categories;
using CatalogServiceApi.Domain.MongoModels;
using Microsoft.EntityFrameworkCore;

namespace CatalogServiceApi.Application.MongoServices.Categories
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
            var category = await _repository.GetByIdAsync(id.ToString());
            if (category == null) throw new KeyNotFoundException("Category Not Found");
            await _repository.RemoveAsync(id.ToString());
            return true;
        }

        public async Task<IEnumerable<CategotyResponseDto>> GetAllAsync()
        {
            var categories = await _repository.GetAll();
            return _mapper.Map<IEnumerable<CategotyResponseDto>>(categories);
        }

        public async Task<CategotyResponseDto> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id.ToString());
            if (category == null) throw new KeyNotFoundException("Category Not Found");
            return _mapper.Map<CategotyResponseDto>(category);
        }

        public async Task<CategotyResponseDto> UpdateAsync(int id, UpdateCategoryDto dto)
        {
            var category = await _repository.GetByIdAsync(id.ToString());
            if (category == null) throw new KeyNotFoundException("Category Not Found");
            var updatedCategory = _mapper.Map<Category>(dto);
            await _repository.UpdateAsync(id.ToString(), updatedCategory);
            return _mapper.Map<CategotyResponseDto>(updatedCategory);
        }
    }
}
