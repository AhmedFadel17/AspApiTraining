using AutoFixture;
using AutoFixture.Xunit2;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Application.Interfaces.Products;
using CatalogServiceAPI.Controllers;
using CatelogServiceAPI.Test.AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CatelogServiceAPI.Test.Featrues.Products
{
    public class ProductsControllerTests
    {
        private readonly Mock<IProductService> _productServiceMock= new Mock<IProductService>();

        [Theory]
        [InlineData (1,2)]
        [InlineData(1, 6)]
        public async Task GetByPrice_Should_return_Success(decimal min, decimal max)
        {
            //Arrange 
            Fixture fixture = new Fixture();
            var prds = fixture.CreateMany<ProductResponseDto>();
            _productServiceMock.Setup(s => s.GetByPriceAsync(min,max)).ReturnsAsync(prds);


            // Act 
            var cntr = new ProductsController(_productServiceMock.Object);
            var res = await cntr.GetByPrice(min, max);


            //Assert 

            res.Should().NotBeNull();
            res.Should().BeOfType<OkObjectResult>();           

        }

        [Theory]
        [AutoMoqData]
        public async Task GetByPrice_ADV_Should_return_Success(decimal min, decimal max,
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

            var res= await sut.All();

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

            var res=await sut.GetById(It.IsAny<int>());

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

            var res= await sut.Create(productDto);

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

            var res= await sut.Update(It.IsAny<int>(), productDto);

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
