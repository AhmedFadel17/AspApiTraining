using AutoFixture.Xunit2;
using CatalogServiceApi.DataAccess.Repostories.Products;
using Moq;
using CatalogServiceApi.Domain.Models;
using FluentAssertions;
using CatalogServiceApi.Test.AutoFixture;
using CatalogServiceApi.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using CatalogServiceApi.DataAccess.Repostories;



namespace CatalogServiceApi.Test.Featrues.Products.Repositories
{
    public class ProductsRepoSuccessTests
    {

        [Theory]
        [AutoMoqData]
        public async Task GetAllAsync_ShouldReturnAllProducts(
                    List<Product> products,
                    [Frozen] ApplicationDbContext context,
                    [Greedy] ProductRepository repository)
        {
            // Arrange
            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetAllAsync();
            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(products.Count, result.Count());
        }


        [Theory]
        [AutoMoqData]
        public async Task GetByNameAsync_Should_Return_Product(
            Product product,
                    [Frozen] ApplicationDbContext context,
                    [Greedy] ProductRepository repository)
        {
            // Arrange
            await context.Products.AddRangeAsync(product);
            await context.SaveChangesAsync();

            // Act
            var res = await repository.GetByNameAsync(It.IsAny<string>());
            // Assert
            res.Should().NotBeNull();
            res.Should().BeAssignableTo<Product>();
        }


    }
}
