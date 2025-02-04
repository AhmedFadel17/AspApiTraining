using AutoFixture;
using AutoFixture.Xunit2;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Application.Interfaces.Products;
using CatalogServiceApi.Domain.Models;
using CatalogServiceAPI.Controllers;
using CatelogServiceAPI.Test.AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatelogServiceAPI.Test.Featrues.Products
{
    public class ProductsControllerTests
    {
        private readonly Mock<IProductService> _productServiceMock= new Mock<IProductService>();

        [Theory]
        [InlineData (1,2,3,4)]
        [InlineData(1, 6, 3, 9)]
        public async Task GetByPrice_Should_return_Success(decimal min, decimal max, decimal minTo, decimal maxTo)
        {
            //Arrange 
            Fixture fixture = new Fixture();
            var prds = fixture.CreateMany<ProductResponseDto>();
            _productServiceMock.Setup(s => s.GetByPriceAsync(min,max,minTo, maxTo)).ReturnsAsync(prds);


            // Act 
            var cntr = new ProductsController(_productServiceMock.Object);
            var res = await cntr.GetByPrice(min, max, minTo, maxTo);


            //Assert 

            res.Should().NotBeNull();
            res.Should().BeOfType<OkObjectResult>();           

        }

        [Theory]
        [AutoMockData]
        public async Task GetByPrice_ADV_Should_return_Success(decimal min, decimal max, decimal minTo, decimal maxTo,
          List<ProductResponseDto> productResponseDtos,
          [Frozen] Mock<IProductService> productServiceMock,
          [Greedy] ProductsController sut)
        {
            //Arrange             
            productServiceMock.Setup(s => s.GetByPriceAsync(min, max, minTo, maxTo)).ReturnsAsync(productResponseDtos);

            // Act            
            var res = await sut.GetByPrice(min, max, minTo, maxTo);

            //Assert 
            res.Should().NotBeNull();
            res.Should().BeOfType<OkObjectResult>();
        }
    }
}
