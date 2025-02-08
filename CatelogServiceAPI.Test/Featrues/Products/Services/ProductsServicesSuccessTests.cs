using AutoFixture.Xunit2;
using CatalogServiceApi.Application.Services.Products;
using CatalogServiceApi.DataAccess.Repostories.Products;
using CatalogServiceAPI.Test.AutoFixture;
using Moq;
using CatalogServiceApi.Domain.Models;
using FluentAssertions;
using CatalogServiceApi.Application.DTOs.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatalogServiceApi.Test.AutoFixture;
using AutoMapper;
using CatalogServiceApi.Application.Mapping;


namespace CatalogServiceApi.Test.Featrues.Products.Services
{
    public class ProductsServicesSuccessTests
    {

        [Theory]
        [AutoMoqData]
        public async Task DeleteAsync_Should_return_Success(Product product,
        [Frozen] Mock<IProductRepository> productRepositoryMock,
        [Greedy] ProductService sut)
        {
            //Arrange             
            productRepositoryMock.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product);

            // Act            
            var res = await sut.DeleteAsync(It.IsAny<int>());

            //Assert 
            res.Should().BeTrue();
        }

        [Theory]
        [AutoMoqData]
        public async Task GetByIdAsync_Should_return_Success(Product product,
        [Frozen] Mock<IProductRepository> productRepositoryMock,
        [Greedy] ProductService sut)
        {
            productRepositoryMock.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product);

            var res = await sut.GetByIdAsync(product.Id);

            res.Should().NotBeNull();
            res.Should().BeAssignableTo<ProductResponseDto>();
        }

        [Theory]
        [AutoMoqData]
        public async Task GetByNameAsync_Should_return_Success(Product product,
        [Frozen] Mock<IProductRepository> productRepositoryMock,
        [Greedy] ProductService sut)
        {
            productRepositoryMock.Setup(s => s.GetByNameAsync(It.IsAny<string>())).ReturnsAsync(product);

            var res = await sut.GetByNameAsync(product.Name);

            res.Should().NotBeNull();
            res.Should().BeAssignableTo<ProductResponseDto>();
        }

        [Theory]
        [AutoMoqData]
        public async Task GetByPriceAsync_Should_return_Success(decimal min, List<Product> products,
        [Frozen] Mock<IProductRepository> productRepositoryMock,
        [Greedy] ProductService sut)
        {

            products.ForEach(p =>
            {
                p.Price = min;
            });
            var max = decimal.MaxValue;
            productRepositoryMock.Setup(s => s.GetByPriceAsync(min, max)).ReturnsAsync(products);

            var res = await sut.GetByPriceAsync(min, max);

            res.Should().NotBeNull();
            res.Should().BeAssignableTo<IEnumerable<ProductResponseDto>>();
            res.ToList().Should().HaveCount(products.Count);
        }

        [Theory]
        [AutoMoqData]
        public async Task GetAllAsync_Should_return_Success(List<Product> products,
        [Frozen] Mock<IProductRepository> productRepositoryMock,
        [Greedy] ProductService sut)
        {
            productRepositoryMock.Setup(s => s.GetAllAsync()).ReturnsAsync(products); 

            var res = await sut.GetAllAsync();

            res.Should().NotBeNull();
            res.Should().BeAssignableTo<IEnumerable<ProductResponseDto>>();
        }
        
        [Theory]
        [AutoMoqData]
        public async Task CreateAsync_Should_return_Success(CreateProductDto createProductDto, Product product,
        [Frozen] Mock<IProductRepository> productRepositoryMock,
        [Greedy] ProductService sut)
        {
            productRepositoryMock.Setup(s => s.CreateAsync(product)).ReturnsAsync(product);

            var res = await sut.CreateAsync(createProductDto);

            res.Should().NotBeNull();
            res.Should().BeAssignableTo<ProductResponseDto>();
        }

        [Theory]
        [AutoMoqData]
        public async Task UpdateAsync_Should_return_Success(UpdateProductDto updateProductDto, Product product,
        [Frozen] Mock<IProductRepository> productRepositoryMock,
        [Greedy] ProductService sut)
        {
            productRepositoryMock.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product);
            productRepositoryMock.Setup(s => s.Update(product));

            var res = await sut.UpdateAsync(It.IsAny<int>(), updateProductDto);

            res.Should().NotBeNull();
            res.Should().BeAssignableTo<ProductResponseDto>();
        }
    }
}
