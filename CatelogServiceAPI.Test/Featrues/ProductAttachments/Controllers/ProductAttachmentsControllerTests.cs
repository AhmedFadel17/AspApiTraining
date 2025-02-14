using AutoFixture.Xunit2;
using CatalogServiceApi.Application.DTOs.ProductAttachments;
using CatalogServiceApi.Application.Interfaces.Products;
using CatalogServiceApi.Test.AutoFixture;
using CatalogServiceApi.WebUi.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CatalogServiceApi.Test.Featrues.ProductAttachments.Controllers
{
    public class ProductAttachmentsControllerTests
    {
        [Theory]
        [AutoMoqData]
        public async Task GetProductAttachments_Should_return_Success(int productAttId,
          ProductAttachmentsResponseDto responseDto,
          [Frozen] Mock<IProductAttachmentsService> serviceMock,
          [Greedy] AttachmentsController sut)
        {
            //Arrange             
            serviceMock.Setup(s => s.GetProductAttachments(productAttId)).ReturnsAsync(responseDto);

            // Act            
            var res = await sut.GetProductAttachments(responseDto.Id);

            //Assert 
            res.Should().NotBeNull();
            res.Should().BeOfType<OkObjectResult>();
        }

        [Theory]
        [AutoMoqData]
        public async Task Create_return_success(CreateProductAttachmentsDto productDto,
          ProductAttachmentsResponseDto responseDto,
          [Frozen] Mock<IProductAttachmentsService> serviceMock,
          [Greedy] AttachmentsController sut)
        {
            serviceMock.Setup(s => s.CreateAsync(productDto)).ReturnsAsync(responseDto);

            var res = await sut.CreateProductAttachments(productDto);

            res.Should().NotBeNull();
            res.Should().BeOfType<OkObjectResult>();
        }


        [Theory]
        [AutoMoqData]
        public async Task Delete_return_success(
           [Frozen] Mock<IProductAttachmentsService> serviceMock,
          [Greedy] AttachmentsController sut)
        {
            serviceMock.Setup(s => s.DeleteAsync(It.IsAny<int>())).ReturnsAsync(true);

            var res = await sut.DeleteProductAttachments(It.IsAny<int>());

            res.Should().NotBeNull();
            res.Should().BeOfType<OkObjectResult>();
        }
    }
}
