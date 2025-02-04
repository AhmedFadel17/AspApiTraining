using AutoFixture.Xunit2;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Application.Interfaces.Products;
using CatalogServiceApi.Application.Services.Products;
using CatalogServiceApi.DataAccess.Repostories.Products;
using CatalogServiceApi.Domain.Models;
using CatalogServiceAPI.Controllers;
using CatelogServiceAPI.Test.AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatelogServiceAPI.Test.Featrues.Products
{
    public class ProductServiceTests
    {
        [Theory]
        [AutoMockData]
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
        [AutoMockData]
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

    }
}
