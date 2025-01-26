using AutoMapper;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Application.Interfaces.Products;
using CatalogServiceApi.DataAccess.Repostories.Products;
using CatalogServiceApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogServiceApi.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(ProductRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductResponseDto> CreateAsync(CreateProductDto dto)
        {
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

        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
        {
            var productsQuery= _repository.GetAll();
            var products = await productsQuery.ToListAsync();
            return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
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
