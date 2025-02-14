using AutoFixture.Xunit2;
using CatalogServiceApi.Application.DTOs.ProductAttachments;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Application.Providers;
using CatalogServiceApi.Application.Services.Products;
using CatalogServiceApi.DataAccess.Repostories.ProductAttachments;
using CatalogServiceApi.Domain.Enums;
using CatalogServiceApi.Domain.Models;
using CatalogServiceApi.Test.AutoFixture;
using FluentAssertions;
using Moq;


namespace CatalogServiceApi.Test.Featrues.ProductAttachments.Services
{
    public class ProductAttachmentsServiceSuccessTests
    {

        [Theory]
        [AutoMoqData]
        public async Task GetProductAttachments_Should_return_Success(
            int productId,
            ProductAttachment productAttachment,
            [Frozen] Mock<IExternalServiceProvider> providerMock,
            [Frozen] Mock<IProductAttachmentsRepository> repositoryMock,
            [Greedy] ProductAttachmentsService sut)
        {

            // Arrange
            var brandDto = new ProductBrandAttachmentsDto { AttachmentType = AttachmentsType.Brand };
            var discountDto = new ProductDiscountAttachmentsDto { AttachmentType = AttachmentsType.Discount };
            var mediaDto = new ProductMediaAttachmentsDto { AttachmentType = AttachmentsType.Media };

            providerMock.Setup(p => p.FetchAttachmentAsync(productId, AttachmentsType.Brand))
                .ReturnsAsync(brandDto);
            providerMock.Setup(p => p.FetchAttachmentAsync(productId, AttachmentsType.Discount))
                .ReturnsAsync(discountDto);
            providerMock.Setup(p => p.FetchAttachmentAsync(productId, AttachmentsType.Media))
                .ReturnsAsync(mediaDto);

            repositoryMock.Setup(r => r.CreateAsync(productAttachment)).ReturnsAsync(productAttachment);

            // Act
            var result = await sut.GetProductAttachments(productId);

            // Assert
            result.Should().NotBeNull();
            providerMock.Verify(p => p.FetchAttachmentAsync(productId, AttachmentsType.Brand), Times.Once);
            providerMock.Verify(p => p.FetchAttachmentAsync(productId, AttachmentsType.Discount), Times.Once);
            providerMock.Verify(p => p.FetchAttachmentAsync(productId, AttachmentsType.Media), Times.Once);
            result.Should().BeAssignableTo<ProductAttachmentsResponseDto>();
        }

        [Theory]
        [AutoMoqData]
        public async Task CreateAsync_Should_return_Success(CreateProductAttachmentsDto createProductDto, ProductAttachment productAttachment,
        [Frozen] Mock<IProductAttachmentsRepository> productRepositoryMock,
        [Greedy] ProductAttachmentsService sut)
        {
            productRepositoryMock.Setup(s => s.CreateAsync(productAttachment)).ReturnsAsync(productAttachment);

            var res = await sut.CreateAsync(createProductDto);

            res.Should().NotBeNull();
            res.Should().BeAssignableTo<ProductAttachmentsResponseDto>();
        }

        [Theory]
        [AutoMoqData]
        public async Task DeleteAsync_Should_return_Success(ProductAttachment productAttachment,
        [Frozen] Mock<IProductAttachmentsRepository> productRepositoryMock,
        [Greedy] ProductAttachmentsService sut)
        {
            //Arrange             
            productRepositoryMock.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(productAttachment);

            // Act            
            var res = await sut.DeleteAsync(It.IsAny<int>());

            //Assert 
            res.Should().BeTrue();
        }
    }
}
