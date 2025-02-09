using CatalogServiceApi.Application.DTOs.Categories;
using CatalogServiceApi.IntegrationTest.AutoFixture;
using CatalogServiceApi.IntegrationTest.Extensions;
using CatalogServiceApi.IntegrationTest.Services;
using FluentAssertions;
using IntegrationTest;

namespace CatalogServiceApi.IntegrationTest.Features.Categories
{
    public class CategoriesUnauthorizedTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CategoriesUnauthorizedTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();

        }

        
        [Theory]
        [AutoMoqData]
        public async Task Create_Should_Return_Unauthorized(CreateCategoryDto productDto)
        {
            // Act
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/categories")
            {
                Content = productDto.ReadAsJsonContent()
            };
            request.Headers.Add("User-Agent", "Integration-Tests");
            var response = await _client.SendAsync(request);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
        }

        [Theory]
        [AutoMoqData]
        public async Task Update_Should_Return_Unauthorized(int id, UpdateCategoryDto updateCategoryDto)
        {
            // Act
            var request = new HttpRequestMessage(HttpMethod.Put, $"/api/categories/{id}")
            {
                Content = updateCategoryDto.ReadAsJsonContent()
            };
            request.Headers.Add("User-Agent", "Integration-Tests");
            var response = await _client.SendAsync(request);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
        }

        [Theory]
        [AutoMoqData]
        public async Task Delete_Should_Return_Unauthorized(int id)
        {
            // Act
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/categories/{id}");
            request.Headers.Add("User-Agent", "Integration-Tests");
            var response = await _client.SendAsync(request);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
        }
    }
}
