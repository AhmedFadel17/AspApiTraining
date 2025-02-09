using CatalogServiceApi.Application.DTOs.Categories;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Domain.Enums;
using CatalogServiceApi.IntegrationTest.AutoFixture;
using CatalogServiceApi.IntegrationTest.Extensions;
using CatalogServiceApi.IntegrationTest.Services;
using FluentAssertions;
using IntegrationTest;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace CatalogServiceApi.IntegrationTest.Features.Categories
{
    public class CategoriesUnaccessibleTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly IAuthService _authService;

        public CategoriesUnaccessibleTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
            using var scope = factory.Services.CreateScope();
            _authService = scope.ServiceProvider.GetRequiredService<IAuthService>();
        }

        [Theory]
        [AutoMoqData]
        public async Task Create_Should_Return_Forbidden(CreateCategoryDto categoryDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Customer);

            // Act
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/categories")
            {
                Content = categoryDto.ReadAsJsonContent()
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");
            var createResponse = await _client.SendAsync(request);

            // Assert
            createResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
        }

        [Theory]
        [AutoMoqData]
        public async Task Delete_Should_Return_Forbidden(int id)
        {
            // Arrange
            var randomRole = new[] { UserRole.Store, UserRole.Customer }
                     .OrderBy(x => Guid.NewGuid())
                     .First();
            string token = await _authService.GetTokenAsync(randomRole);

            // Act
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/categories/{id}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            var deleteResponse = await _client.SendAsync(request);

            // Assert
            deleteResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
        }

        [Theory]
        [AutoMoqData]
        public async Task Update_Should_Return_Forbidden(int id, UpdateCategoryDto categoryDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Customer);

            // Act
            var updateRequest = new HttpRequestMessage(HttpMethod.Put, $"/api/categories/{id}")
            {
                Content = categoryDto.ReadAsJsonContent()
            };
            updateRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            updateRequest.Headers.Add("User-Agent", "Integration-Tests");

            var updateResponse = await _client.SendAsync(updateRequest);

            // Assert
            updateResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
        }

    }
}
