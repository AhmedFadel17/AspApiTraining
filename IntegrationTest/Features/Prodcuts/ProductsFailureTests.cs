using Azure;
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
    public class ProductFailureTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly AuthService _authService;

        public ProductFailureTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
            _authService = new AuthService();
        }

       
        [Theory]
        [AutoMoqData]
        public async Task GetById_Should_Return_NotFound_When_Product_Does_Not_Exist(CreateProductDto productDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);
            var nonExistentProductId = int.MaxValue;

            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/products/{nonExistentProductId}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        [Theory]
        [AutoMoqData]
        public async Task Update_Should_Return_NotFound_When_Product_Does_Not_Exist(UpdateProductDto updatedProductDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);
            var nonExistentProductId = int.MaxValue;

            var request = new HttpRequestMessage(HttpMethod.Put, $"/api/products/{nonExistentProductId}")
            {
                Content = updatedProductDto.ReadAsJsonContent()
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        [Theory]
        [AutoMoqData]
        public async Task Delete_Should_Return_NotFound_When_Product_Does_Not_Exist(CreateProductDto productDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);
            var nonExistentProductId = int.MaxValue; 

            var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/products/{nonExistentProductId}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        
    }
}
