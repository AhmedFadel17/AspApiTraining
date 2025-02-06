using AutoFixture;
using AutoFixture.Xunit2;
using CatalogServiceApi.Application.DTOs.Categories;
using CatalogServiceApi.Application.Interfaces.Categories;
using CatalogServiceApi.Application.Services.Categories;
using CatalogServiceApi.Test.AutoFixture;
using CatalogServiceAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CatalogServiceApi.Test.Features.Categories.Controllers
{
    public class CategoriesControllerTests
    {
        [Theory]
        [AutoMoqData]
        public async Task All_return_Success(List<CategoryResponseDto> categoryResponseDtos,
            [Frozen] Mock<ICategoryService> categoryServiceMock,
            [Greedy] CategoriesController sut)
        {
            categoryServiceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(categoryResponseDtos);

            var res = await sut.All();

            res.Should().NotBeNull();
            res.Should().BeOfType<OkObjectResult>();
        }

        [Theory]
        [AutoMoqData]
        public async Task GetById_return_success(CategoryResponseDto categoryResponseDto,
            [Frozen] Mock<ICategoryService> categoryServiceMock,
            [Greedy] CategoriesController sut)
        {
            categoryServiceMock.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(categoryResponseDto);

            var res = await sut.GetById(It.IsAny<int>());

            res.Should().NotBeNull();
            res.Should().BeOfType<OkObjectResult>();
        }

        [Theory]
        [AutoMoqData]
        public async Task Create_return_success(CreateCategoryDto categoryDto,
        CategoryResponseDto categoryResponseDto,
            [Frozen] Mock<ICategoryService> categoryServiceMock,
            [Greedy] CategoriesController sut)
        {
            categoryServiceMock.Setup(s => s.CreateAsync(categoryDto)).ReturnsAsync(categoryResponseDto);

            var res = await sut.Create(categoryDto);

            res.Should().NotBeNull();
            res.Should().BeOfType<OkObjectResult>();
        }

        [Theory]
        [AutoMoqData]
        public async Task Update_return_success(UpdateCategoryDto categoryDto,
        CategoryResponseDto categoryResponseDto,
            [Frozen] Mock<ICategoryService> categoryServiceMock,
            [Greedy] CategoriesController sut)
        {
            categoryServiceMock.Setup(s => s.UpdateAsync(It.IsAny<int>(), categoryDto)).ReturnsAsync(categoryResponseDto);

            var res = await sut.Update(It.IsAny<int>(), categoryDto);

            res.Should().NotBeNull();
            res.Should().BeOfType<OkObjectResult>();
        }

        [Theory]
        [AutoMoqData]
        public async Task Delete_return_success([Frozen] Mock<ICategoryService> categoryServiceMock,
            [Greedy] CategoriesController sut)
        {
            categoryServiceMock.Setup(s => s.DeleteAsync(It.IsAny<int>())).ReturnsAsync(true);

            var res = await sut.Delete(It.IsAny<int>());

            res.Should().NotBeNull();
            res.Should().BeOfType<OkObjectResult>();
        }
    }
}
