using AutoFixture;
using AutoFixture.Xunit2;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Application.Interfaces.Products;
using CatalogServiceApi.Test.AutoFixture;
using CatalogServiceAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CatalogServiceApi.Test.Featrues.Products.Controllers
{
    public class ProductsControllerTests
    {
        [Theory]
        [AutoMoqData]
        public async Task GetByPrice_Should_return_Success(decimal min, decimal max,
          List<ProductResponseDto> productResponseDtos,
          [Frozen] Mock<IProductService> productServiceMock,
          [Greedy] ProductsController sut)
        {
            //Arrange             
            productServiceMock.Setup(s => s.GetByPriceAsync(min, max)).ReturnsAsync(productResponseDtos);

            // Act            
            var res = await sut.GetByPrice(min, max);

            //Assert 
            res.Should().NotBeNull();
            res.Should().BeOfType<OkObjectResult>();
        }



        [Theory]
        [AutoMoqData]
        public async Task All_return_Success(List<ProductResponseDto> productResponseDtos,
            [Frozen] Mock<IProductService> productServiceMock,
            [Greedy] ProductsController sut)
        {
            productServiceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(productResponseDtos);

            var res = await sut.All();

            res.Should().NotBeNull();
            res.Should().BeOfType<OkObjectResult>();
        }

        [Theory]
        [AutoMoqData]
        public async Task GetById_return_success(ProductResponseDto productResponseDto,
            [Frozen] Mock<IProductService> productServiceMock,
            [Greedy] ProductsController sut)
        {
            productServiceMock.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(productResponseDto);

            var res = await sut.GetById(It.IsAny<int>());

            res.Should().NotBeNull();
            res.Should().BeOfType<OkObjectResult>();
        }

        [Theory]
        [AutoMoqData]
        public async Task Create_return_success(CreateProductDto productDto,
            ProductResponseDto productResponseDto,
            [Frozen] Mock<IProductService> productServiceMock,
            [Greedy] ProductsController sut)
        {
            productServiceMock.Setup(s => s.CreateAsync(productDto)).ReturnsAsync(productResponseDto);

            var res = await sut.Create(productDto);

            res.Should().NotBeNull();
            res.Should().BeOfType<OkObjectResult>();
        }

        [Theory]
        [AutoMoqData]
        public async Task Update_return_success(UpdateProductDto productDto,
            ProductResponseDto productResponseDto,
            [Frozen] Mock<IProductService> productServiceMock,
            [Greedy] ProductsController sut)
        {
            productServiceMock.Setup(s => s.UpdateAsync(It.IsAny<int>(), productDto)).ReturnsAsync(productResponseDto);

            var res = await sut.Update(It.IsAny<int>(), productDto);

            res.Should().NotBeNull();
            res.Should().BeOfType<OkObjectResult>();
        }

        [Theory]
        [AutoMoqData]
        public async Task Delete_return_success([Frozen] Mock<IProductService> productServiceMock,
            [Greedy] ProductsController sut)
        {
            productServiceMock.Setup(s => s.DeleteAsync(It.IsAny<int>())).ReturnsAsync(true);

            var res = await sut.Delete(It.IsAny<int>());

            res.Should().NotBeNull();
            res.Should().BeOfType<OkObjectResult>();
        }
    }
}
