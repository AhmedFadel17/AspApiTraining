using AutoFixture.Xunit2;
using CatalogServiceApi.Application.Cache;
using CatalogServiceApi.Application.DTOs.ProductAttachments;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Application.Services.Products;
using CatalogServiceApi.DataAccess.Repostories.ProductAttachments;
using CatalogServiceApi.DataAccess.Repostories.Products;
using CatalogServiceApi.Domain.Models;
using CatalogServiceApi.Test.AutoFixture;
using FluentAssertions;
using Moq;
using Moq.Protected;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CatalogServiceApi.Test.Featrues.ProductAttachments.Services
{
    public class ProductAttachmentsServiceSuccessTests
    {

        [Theory]
        [AutoMoqData]
        public async Task GetProductAttachments_Should_return_Success(
            string url,
            ProductAttachment productAttachment,
            ProductMediaAttachmentsDto mediaDto,
            ProductDiscountAttachmentsDto discountDto,
            ProductBrandAttachmentsDto brandDto,
            Mock<HttpMessageHandler> httpMessageHandlerMock,
            [Frozen] Mock<IProductAttachmentsRepository> productAttRepositoryMock,
            [Greedy] ProductAttachmentsService sut)
        {
            // Arrange
            SetupHttpResponse(httpMessageHandlerMock, url, mediaDto);
            SetupHttpResponse(httpMessageHandlerMock, url, discountDto);
            SetupHttpResponse(httpMessageHandlerMock, url, brandDto);

            // Mock Database Insertions
            productAttRepositoryMock.Setup(s => s.CreateAsync(It.IsAny<ProductAttachment>()))
                                    .ReturnsAsync(productAttachment);

            // Act
            var result = await sut.GetProductAttachments(productAttachment.ProductId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ProductAttachmentsResponseDto>();
        }

        private void SetupHttpResponse<T>(Mock<HttpMessageHandler> httpMessageHandlerMock, string url, T responseDto)
        {
            var jsonResponse = JsonSerializer.Serialize(responseDto);
            var mockResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonResponse)
            };

            httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == url),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);
        }
    }
}
