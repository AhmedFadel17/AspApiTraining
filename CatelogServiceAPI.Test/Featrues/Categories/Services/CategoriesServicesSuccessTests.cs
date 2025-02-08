using AutoFixture.Xunit2;
using CatalogServiceApi.Application.Services.Categories;
using Moq;
using CatalogServiceApi.Domain.Models;
using FluentAssertions;
using CatalogServiceApi.Application.DTOs.Categories;
using CatalogServiceApi.Test.AutoFixture;
using CatalogServiceApi.DataAccess.Repostories.Categories;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Application.Services.Products;
using CatalogServiceApi.DataAccess.Repostories.Products;

namespace CatalogServiceApi.Test.Features.Categories.Services
{
    public class CategoryServicesSuccessTests
    {
        [Theory]
        [AutoMoqData]
        public async Task DeleteAsync_Should_return_Success(Category category,
        [Frozen] Mock<ICategoryRepository> categoryRepositoryMock,
        [Greedy] CategoryService sut)
        {
           
            categoryRepositoryMock.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(category);
           
            var res = await sut.DeleteAsync(It.IsAny<int>());

            res.Should().BeTrue();
        }

        [Theory]
        [AutoMoqData]
        public async Task GetAllAsync_Should_return_Success(List<Category> categories,
        [Frozen] Mock<ICategoryRepository> categoryRepositoryMock,
        [Greedy] CategoryService sut)
        {
            categoryRepositoryMock.Setup(s => s.GetAllAsync()).ReturnsAsync(categories);

            var res = await sut.GetAllAsync();

            res.Should().NotBeNull();
            res.Should().BeAssignableTo<IEnumerable<CategoryResponseDto>>();
        }

        [Theory]
        [AutoMoqData]
        public async Task GetByIdAsync_Should_return_Success(Category category,
        [Frozen] Mock<ICategoryRepository> categoryRepositoryMock,
        [Greedy] CategoryService sut)
        {
            categoryRepositoryMock.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(category);

            var res = await sut.GetByIdAsync(It.IsAny<int>());

            res.Should().NotBeNull();
            res.Should().BeAssignableTo<CategoryResponseDto>();
        }


        [Theory]
        [AutoMoqData]
        public async Task CreateAsync_Should_return_Success(CreateCategoryDto createCategoryDto, Category category,
        [Frozen] Mock<ICategoryRepository> categoryRepositoryMock,
        [Greedy] CategoryService sut)
        {
            categoryRepositoryMock.Setup(s => s.CreateAsync(category)).ReturnsAsync(category);

            var res = await sut.CreateAsync(createCategoryDto);

            res.Should().NotBeNull();
            res.Should().BeAssignableTo<CategoryResponseDto>();
        }

        [Theory]
        [AutoMoqData]
        public async Task UpdateAsync_Should_return_Success(UpdateCategoryDto updateCategoryDto, Category category,
        [Frozen] Mock<ICategoryRepository> categoryRepositoryMock,
        [Greedy] CategoryService sut)
        {
            categoryRepositoryMock.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(category);
            categoryRepositoryMock.Setup(s => s.Update(category));

            var res = await sut.UpdateAsync(It.IsAny<int>(), updateCategoryDto);

            res.Should().NotBeNull();
            res.Should().BeAssignableTo<CategoryResponseDto>();
        }
    }
}
