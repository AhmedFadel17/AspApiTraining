using AutoFixture.Xunit2;
using CatalogServiceApi.Application.DTOs.Categories;
using CatalogServiceApi.Application.Services.Categories;
using CatalogServiceApi.DataAccess.Repostories.Categories;
using CatalogServiceApi.Domain.Models;
using FluentAssertions;
using Moq;
using CatalogServiceApi.Test.AutoFixture;

namespace CatalogServiceApi.Test.Features.Categories.Services
{
    public class CategoriesServiceFailureTests
    {
        [Theory]
        [AutoMoqData]
        public async Task DeleteAsync_non_existed_should_throw_Exception(
         [Frozen] Mock<ICategoryRepository> categoryRepositoryMock,
         [Greedy] CategoryService sut)
        {            
            categoryRepositoryMock.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Category)null);

            Func<Task> action = () => sut.DeleteAsync(It.IsAny<int>());

            await action.Should().ThrowAsync<KeyNotFoundException>();
        }

        [Theory]
        [AutoMoqData]
        public async Task GetByIdAsync_non_existed_should_throw_Exception(
            [Frozen] Mock<ICategoryRepository> categoryRepositoryMock,
            [Greedy] CategoryService sut)
        {
            categoryRepositoryMock.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Category)null);

            Func<Task> action = () => sut.GetByIdAsync(It.IsAny<int>());

            await action.Should().ThrowAsync<KeyNotFoundException>();
        }

        [Theory]
        [AutoMoqData]
        public async Task UpdateAsync_non_existed_should_throw_Exception(UpdateCategoryDto updateCategoryDto, Category category,
        [Frozen] Mock<ICategoryRepository> categoryRepositoryMock,
        [Greedy] CategoryService sut)
        {
            categoryRepositoryMock.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Category)null);

            Func<Task> action = () => sut.UpdateAsync(It.IsAny<int>(), updateCategoryDto);

            await action.Should().ThrowAsync<KeyNotFoundException>();
        }
    }

}
