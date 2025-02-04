using AutoMapper;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Application.Interfaces.Products;
using CatalogServiceApi.MongoDbAccess.Repostories.Products;
using CatalogServiceApi.Domain.MongoModels;
using Microsoft.EntityFrameworkCore;


namespace CatalogServiceApi.Application.MongoServices.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductResponseDto>> GetByPriceAsync(decimal minFrom, decimal maxFrom, decimal minTo, decimal maxTo)
        {
            var product = await _repository.GetByPriceAsync(minFrom, maxFrom, minTo, maxTo);
            if (product == null) throw new KeyNotFoundException("Product Not Found");
            return _mapper.Map< IEnumerable<ProductResponseDto>>(product);
        }
        public async Task<IEnumerable<ProductResponseDto>> CreateWithBatchedKeysAsync(List<CreateProductDto> dto)
        {
            var products = _mapper.Map<IEnumerable<Product>>(dto);
            var partitionKeys = products.Select(p => p.CategoryId.ToString()).ToList();
            await _repository.AddBatchAsync(products,partitionKeys);
            return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
        }

        public async Task<ProductResponseDto> CreateAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            var createdProduct = await _repository.CreateAsync(product);
            return _mapper.Map<ProductResponseDto>(createdProduct);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id.ToString());
            if (product == null) throw new KeyNotFoundException("Product Not Found");
            await _repository.RemoveAsync(id.ToString());
            return true;
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
        {
            var products=await _repository.GetAll();
            return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
        }

        public async Task<ProductResponseDto> GetByIdAsync(int id)
        {
            var product= await _repository.GetByIdAsync(id.ToString());
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
            var product = await _repository.GetByIdAsync(id.ToString());
            if (product == null) throw new KeyNotFoundException("Product Not Found");
            var updatedProduct = _mapper.Map<Product>(dto);
            await _repository.UpdateAsync(id.ToString(), updatedProduct);
            return _mapper.Map<ProductResponseDto>(updatedProduct);
        }

        
    }
}
