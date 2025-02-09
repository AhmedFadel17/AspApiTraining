using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Domain.Enums;
using CatalogServiceApi.IntegrationTest.AutoFixture;
using CatalogServiceApi.IntegrationTest.Extensions;
using CatalogServiceApi.IntegrationTest.Services;
using FluentAssertions;
using IntegrationTest;
using System.Net.Http.Headers;

namespace CatalogServiceApi.IntegrationTest.Features.Products
{
    public class ProductsUnaccessibleTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly AuthService _authService;

        public ProductsUnaccessibleTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
            _authService = new AuthService();
        }

        [Theory]
        [AutoMoqData]
        public async Task Create_Should_Return_Forbidden(CreateProductDto productDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Customer);

            // Act
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/products")
            {
                Content = productDto.ReadAsJsonContent()
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
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/products/{id}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            var deleteResponse = await _client.SendAsync(request);

            // Assert
            deleteResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
        }

        [Theory]
        [AutoMoqData]
        public async Task Update_Should_Return_Forbidden(int id,UpdateProductDto productDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Customer);

            // Act
            var updateRequest = new HttpRequestMessage(HttpMethod.Put, $"/api/products/{id}")
            {
                Content = productDto.ReadAsJsonContent()
            };
            updateRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            updateRequest.Headers.Add("User-Agent", "Integration-Tests");

            var updateResponse = await _client.SendAsync(updateRequest);

            // Assert
            updateResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
        }

    }
}
