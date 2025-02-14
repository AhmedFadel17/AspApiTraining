using AutoFixture.Xunit2;
using CatalogServiceApi.Application.DTOs.ProductAttachments;
using CatalogServiceApi.Application.Providers;
using CatalogServiceApi.Application.Services.Products;
using CatalogServiceApi.DataAccess.Repostories.ProductAttachments;
using CatalogServiceApi.DataAccess.Repostories.Products;
using CatalogServiceApi.Domain.Models;
using CatalogServiceApi.Test.AutoFixture;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogServiceApi.Test.Featrues.ProductAttachments.Services
{
    public class ProductAttachmentsServiceFailureTests
    {

        [Theory]
        [AutoMoqData]
        public async Task DeleteAsync_non_exsited_should_throw_Exception(
         [Frozen] Mock<IProductAttachmentsRepository> productRepositoryMock,
        [Greedy] ProductAttachmentsService sut)
        {
            //Arrange             
            productRepositoryMock.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((ProductAttachment)null);

            // Act            
            Func<Task> action = () => sut.DeleteAsync(It.IsAny<int>());

            //Assert 
            await action.Should().ThrowAsync<KeyNotFoundException>();
        }
    }
}
