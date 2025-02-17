using AutoMapper;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Application.Interfaces.Products;
using CatalogServiceApi.DataAccess.Repostories.Categories;
using CatalogServiceApi.DataAccess.Repostories.Products;
using CatalogServiceApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogServiceApi.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repository,ICategoryRepository categoryRepository,IMapper mapper)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ProductResponseDto> CreateAsync(CreateProductDto dto)
        {
            var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
            if (category == null) throw new KeyNotFoundException("Category Not Found");
            var product = _mapper.Map<Product>(dto);
            var createdProduct = await _repository.CreateAsync(product);
            return _mapper.Map<ProductResponseDto>(createdProduct);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) throw new KeyNotFoundException("Product Not Found");
            _repository.Remove(product);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProductResponseDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<List<ProductResponseDto>>(products);
        }

        public async Task<ProductResponseDto> GetByIdAsync(int id)
        {
            var product= await _repository.GetByIdAsync(id);
            if (product == null) throw new KeyNotFoundException("Product Not Found");
            return _mapper.Map<ProductResponseDto>(product);
        }

        public async Task<ProductResponseDto> GetByNameAsync(string name)
        {
            var product = await _repository.GetByNameAsync(name);
            if (product == null) throw new KeyNotFoundException("Product Not Found");
            return _mapper.Map<ProductResponseDto>(product);
        }

        public async Task<List<ProductResponseDto>> GetByPriceAsync(decimal min, decimal max)
        {
            if (max <= min) throw new ArgumentException("Max must be greater than min");
            var products = (await _repository.GetByPriceAsync(min,max)).ToList();
         
            return _mapper.Map<List<ProductResponseDto>>(products);
        }

        public async Task<ProductResponseDto> UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) throw new KeyNotFoundException("Product Not Found");
            var updatedProduct = _mapper.Map<Product>(dto);
            _repository.Update(updatedProduct);
            await _repository.SaveChangesAsync();
            return _mapper.Map<ProductResponseDto>(updatedProduct);
        }
    }
}
