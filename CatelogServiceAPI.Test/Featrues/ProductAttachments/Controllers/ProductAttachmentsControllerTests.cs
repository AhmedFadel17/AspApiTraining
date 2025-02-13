using AutoFixture.Xunit2;
using CatalogServiceApi.Application.DTOs.ProductAttachments;
using CatalogServiceApi.Application.Interfaces.Products;
using CatalogServiceApi.Test.AutoFixture;
using CatalogServiceAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CatalogServiceApi.Test.Featrues.ProductAttachments.Controllers
{
    public class ProductAttachmentsControllerTests
    {
        [Theory]
        [AutoMoqData]
        public async Task GetById_Should_return_Success(int productId,
          ProductAttachmentsResponseDto responseDto,
          [Frozen] Mock<IProductAttachmentsService> serviceMock,
          [Greedy] ProductsController sut)
        {
            //Arrange             
            serviceMock.Setup(s => s.GetProductAttachments(productId)).ReturnsAsync(responseDto);

            // Act            
            var res = await sut.GetById(responseDto.Id);

            //Assert 
            res.Should().NotBeNull();
            res.Should().BeOfType<OkObjectResult>();
        }
    }
}
