using AutoFixture.Xunit2;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Application.Interfaces.Products;
using CatalogServiceApi.Application.Services.Products;
using CatalogServiceApi.DataAccess.Repostories.Products;
using CatalogServiceApi.Domain.Models;
using CatelogServiceAPI.Test.AutoFixture;
using FluentAssertions;
using Moq;
using AutoFixture;
using System.Runtime.InteropServices;
using CatalogServiceApi.Test.AutoFixture;

namespace CatelogServiceAPI.Test.Featrues.Products.Services.Failure
{
    public class ProductsServiceFailureTests
    {
       

        [Theory]
        [AutoMoqData]
        public async Task DeleteAsync_non_exsited_should_throw_Exception(
         [Frozen] Mock<IProductRepository> productRepositoryMock,
         [Greedy] ProductService sut)
        {
            //Arrange             
            productRepositoryMock.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Product)null);

            // Act            
            Func<Task> action = () => sut.DeleteAsync(It.IsAny<int>());

            //Assert 
           await action.Should().ThrowAsync<KeyNotFoundException>();
        }

        [Theory]
        [AutoMoqData]
        public async Task GetByIdAsync_non_exsited_should_throw_Exception(
            [Frozen] Mock<IProductRepository> productRepositoryMock,
            [Greedy] ProductService sut)
        {
            productRepositoryMock.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Product)null);

            Func<Task> action = () => sut.GetByIdAsync(It.IsAny<int>());

            await action.Should().ThrowAsync<KeyNotFoundException>();
        }

        [Theory]
        [AutoMoqData]
        public async Task GetByNameAsync_non_exsited_should_throw_Exception(
        [Frozen] Mock<IProductRepository> productRepositoryMock,
        [Greedy] ProductService sut)
        {
            productRepositoryMock.Setup(s => s.GetByNameAsync(It.IsAny<string>())).ReturnsAsync((Product)null);

            Func<Task> action = () => sut.GetByNameAsync(It.IsAny<string>());

            await action.Should().ThrowAsync<KeyNotFoundException>();
        }

        [Theory]
        [InlineAutoMoqData(100, 50)]
        [InlineAutoMoqData(50, 50)]
        public async Task GetByPriceAsync_should_throw_Exception(decimal min, decimal max,List<Product> products,
        [Frozen] Mock<IProductRepository> productRepositoryMock,
        [Greedy] ProductService sut)
        {
            productRepositoryMock.Setup(s => s.GetByPriceAsync(min, max)).ReturnsAsync(products);

            Func<Task> action = () => sut.GetByPriceAsync(min, max);
            
            await action.Should().ThrowAsync<ArgumentException>();

        }



        [Theory]
        [AutoMoqData]
        public async Task UpdateAsync_non_exsited_should_throw_Exception(UpdateProductDto updateProductDto, Product product,
        [Frozen] Mock<IProductRepository> productRepositoryMock,
        [Greedy] ProductService sut)
        {
            productRepositoryMock.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Product)null);

            Func<Task> action = () => sut.UpdateAsync(It.IsAny<int>(),updateProductDto);

            await action.Should().ThrowAsync<KeyNotFoundException>();
        }

    }

    public class PriceRange
    {
        public decimal Min { get; set; }
        public decimal Max { get; set; }
    }
}
