using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.IntegrationTest.AutoFixture;
using CatalogServiceApi.IntegrationTest.Extensions;
using CatalogServiceApi.IntegrationTest.Services;
using FluentAssertions;
using IntegrationTest;

namespace CatalogServiceApi.IntegrationTest.Features.Products
{
    public class ProductsUnauthorizedTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ProductsUnauthorizedTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();

        }


        [Theory]
        [AutoMoqData]
        public async Task Create_Should_Return_Unauthorized(CreateProductDto productDto)
        {
            // Act
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/products")
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
        public async Task Update_Should_Return_Unauthorized(int id,UpdateProductDto updateProductDto)
        {
            // Act
            var request = new HttpRequestMessage(HttpMethod.Put, $"/api/products/{id}")
            {
                Content = updateProductDto.ReadAsJsonContent()
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
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/products/{id}");
            request.Headers.Add("User-Agent", "Integration-Tests");
            var response = await _client.SendAsync(request);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
        }
    }
}
