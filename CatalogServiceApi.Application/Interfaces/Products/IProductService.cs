﻿using CatalogServiceApi.Application.DTOs.Products;

namespace CatalogServiceApi.Application.Interfaces.Products
{
    public interface IProductService
    {
        Task<ProductResponseDto> GetByIdAsync(int id);
        Task<ProductResponseDto> GetByNameAsync(string name);
        Task<List<ProductResponseDto>> GetByPriceAsync(decimal min, decimal max);
        Task<List<ProductResponseDto>> GetAllAsync();
        Task<ProductResponseDto> CreateAsync(CreateProductDto dto);
        Task<ProductResponseDto> UpdateAsync(int id, UpdateProductDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
