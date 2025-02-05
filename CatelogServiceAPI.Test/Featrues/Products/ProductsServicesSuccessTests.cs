﻿using AutoFixture.Xunit2;
using CatalogServiceApi.Application.Services.Products;
using CatalogServiceApi.DataAccess.Repostories.Products;
using CatelogServiceAPI.Test.AutoFixture;
using Moq;
using CatalogServiceApi.Domain.Models;
using FluentAssertions;
using CatalogServiceApi.Application.DTOs.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatalogServiceApi.Test.AutoFixture;


namespace CatalogServiceApi.Test.Featrues.Products
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

            var res = await sut.GetByIdAsync(It.IsAny<int>());

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

            var res = await sut.GetByIdAsync(It.IsAny<int>());

            res.Should().NotBeNull();
            res.Should().BeAssignableTo<ProductResponseDto>();
        }

        [Theory]
        [InlineAutoMoqData(10, 500)]
        public async Task GetByPriceAsync_Should_return_Success(decimal min, decimal max,List<Product> products,
        [Frozen] Mock<IProductRepository> productRepositoryMock,
        [Greedy] ProductService sut)
        {
            productRepositoryMock.Setup(s => s.GetByPriceAsync(min,max)).ReturnsAsync(products);

            var res = await sut.GetByPriceAsync(min,max);

            res.Should().NotBeNull();
            res.Should().BeAssignableTo<IEnumerable<ProductResponseDto>>();
        }

        [Theory]
        [AutoMoqData]
        public async Task GetAllAsync_Should_return_Success(IQueryable<Product> products,
        [Frozen] Mock<IProductRepository> productRepositoryMock,
        [Greedy] ProductService sut)
        {
            productRepositoryMock.Setup(s => s.GetAll()).Returns(products.AsQueryable());

            var res = await sut.GetAllAsync();

            res.Should().NotBeNull();
            res.Should().BeAssignableTo<IEnumerable<ProductResponseDto>>();
        }

        [Theory]
        [AutoMoqData]
        public async Task CreateAsync_Should_return_Success(CreateProductDto createProductDto,Product product,
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


        //Task<IEnumerable<ProductResponseDto>> CreateWithBatchedKeysAsync(List<CreateProductDto> dto);
    }
}
