using Azure;
using CatalogServiceApi.Application.DTOs.Categories;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Domain.Enums;
using CatalogServiceApi.Domain.Models;
using CatalogServiceApi.IntegrationTest.AutoFixture;
using CatalogServiceApi.IntegrationTest.Extensions;
using CatalogServiceApi.IntegrationTest.Services;
using FluentAssertions;
using IntegrationTest;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace CatalogServiceApi.IntegrationTest.Features.Categories
{
    public class CategoriesSuccessTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly IAuthService _authService;

        public CategoriesSuccessTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
            using var scope = factory.Services.CreateScope();
            _authService = scope.ServiceProvider.GetRequiredService<IAuthService>();
        }

        [Theory]
        [AutoMoqData]
        public async Task GetAll_Should_Return_Category_List(CreateCategoryDto categoryDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);
            var createResponse = await CreateCategory(categoryDto, token);
            var createdCategory = await createResponse.Content.ReadAsJsonAsync<CategoryResponseDto>();

            // Act
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/categories");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            var response = await _client.SendAsync(request);
            var categories = await response.Content.ReadAsJsonAsync<List<CategoryResponseDto>>();

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            categories.Should().NotBeNull();
            categories.Should().NotBeEmpty();
            //categories.Count.Should().Be(1);
            //categories.First().Id.Should().Be(createdCategory.Id);

        }

        [Theory]
        [AutoMoqData]
        public async Task GetById_Should_Return_Correct_Category(CreateCategoryDto categoryDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);
            var createResponse = await CreateCategory(categoryDto, token);
            var createdCategory = await createResponse.Content.ReadAsJsonAsync<CategoryResponseDto>();

            // Act
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/categories/{createdCategory.Id}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            var response = await _client.SendAsync(request);
            var category = await response.Content.ReadAsJsonAsync<CategoryResponseDto>();

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            category.Should().NotBeNull();
            category.Id.Should().Be(createdCategory.Id);
            category.Name.Should().Be(createdCategory.Name);

            await DeleteCategory(category.Id, token);
        }

        [Theory]
        [AutoMoqData]
        public async Task Create_Should_Return_Created_Category(CreateCategoryDto categoryDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);

            // Act
            var createResponse = await CreateCategory(categoryDto, token);
            var createdCategory = await createResponse.Content.ReadAsJsonAsync<CategoryResponseDto>();

            // Assert
            createResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            createdCategory.Should().NotBeNull();
            createdCategory.Name.Should().Be(categoryDto.Name);

            await DeleteCategory(createdCategory.Id, token);
        }

        [Theory]
        [AutoMoqData]
        public async Task Update_Should_Modify_Category(CreateCategoryDto categoryDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);
            var createResponse = await CreateCategory(categoryDto, token);
            var createdCategory = await createResponse.Content.ReadAsJsonAsync<CategoryResponseDto>();

            var updatedCategoryDto = new UpdateCategoryDto
            {
                Name = "Updated " + createdCategory.Name,
                Description = createdCategory.Description + " Updated",
            };

            // Act
            var updateRequest = new HttpRequestMessage(HttpMethod.Put, $"/api/categories/{createdCategory.Id}")
            {
                Content = updatedCategoryDto.ReadAsJsonContent()
            };
            updateRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            updateRequest.Headers.Add("User-Agent", "Integration-Tests");

            var updateResponse = await _client.SendAsync(updateRequest);
            var updatedCategory = await updateResponse.Content.ReadAsJsonAsync<CategoryResponseDto>();

            // Assert
            updateResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            updatedCategory.Name.Should().Be(updatedCategoryDto.Name);
            updatedCategory.Description.Should().Be(updatedCategoryDto.Description);

            await DeleteCategory(updatedCategory.Id, token);
        }

        [Theory]
        [AutoMoqData]
        public async Task Delete_Should_Remove_Product(CreateCategoryDto categoryDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);
            var createResponse = await CreateCategory(categoryDto, token);
            var createdCategory = await createResponse.Content.ReadAsJsonAsync<CategoryResponseDto>();

            // Act
            var deleteResponse = await DeleteCategory(createdCategory.Id, token);

            // Assert
            deleteResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        private async Task<HttpResponseMessage> CreateCategory(CreateCategoryDto categoryDto, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/categories")
            {
                Content = categoryDto.ReadAsJsonContent()
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            return await _client.SendAsync(request);
        }

        private async Task<HttpResponseMessage> DeleteCategory(int id, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/categories/{id}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            return await _client.SendAsync(request);
        }
    }
}
