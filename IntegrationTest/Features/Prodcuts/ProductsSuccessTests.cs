using Azure;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Domain.Enums;
using CatalogServiceApi.IntegrationTest.AutoFixture;
using CatalogServiceApi.IntegrationTest.Extensions;
using CatalogServiceApi.IntegrationTest.Services;
using FluentAssertions;
using IntegrationTest;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace CatalogServiceApi.IntegrationTest.Features.Products
{
    public class ProductsSuccessTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly IAuthService _authService;

        public ProductsSuccessTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
            using var scope = factory.Services.CreateScope();
            _authService = scope.ServiceProvider.GetRequiredService<IAuthService>();
        }

        [Theory]
        [AutoMoqData]
        public async Task GetAll_Should_Return_Product_List(CreateProductDto productDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);
            var createResponse = await CreateProduct(productDto, token);
            var createdProduct = await createResponse.Content.ReadAsJsonAsync<ProductResponseDto>();

            // Act
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/products");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            var response = await _client.SendAsync(request);
            var products = await response.Content.ReadAsJsonAsync<List<ProductResponseDto>>();

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            products.Should().NotBeNull();
            products.Should().NotBeEmpty();
            //products.Count.Should().Be(1); 
            //products.First().Id.Should().Be(createdProduct.Id);
        }

        [Theory]
        [AutoMoqData]
        public async Task GetByPrice_Should_Return_Product_List(CreateProductDto productDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);
            var createResponse = await CreateProduct(productDto, token);
            var createdProduct = await createResponse.Content.ReadAsJsonAsync<ProductResponseDto>();
            // Act
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/products/by-price-range?min={createdProduct.Price-10}&max={createdProduct.Price+10}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            var response = await _client.SendAsync(request);
            var products = await response.Content.ReadAsJsonAsync<List<ProductResponseDto>>();

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            products.Should().NotBeNull();
            products.Should().NotBeEmpty();
            //products.Count.Should().Be(1);
            //products.First().Id.Should().Be(createdProduct.Id);
        }


        [Theory]
        [AutoMoqData]
        public async Task GetById_Should_Return_Correct_Product(CreateProductDto productDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);
            var createResponse = await CreateProduct(productDto, token);
            var createdProduct = await createResponse.Content.ReadAsJsonAsync<ProductResponseDto>();

            // Act
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/products/{createdProduct.Id}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            var response = await _client.SendAsync(request);
            var product = await response.Content.ReadAsJsonAsync<ProductResponseDto>();

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            product.Should().NotBeNull();
            product.Id.Should().Be(createdProduct.Id);
            product.Name.Should().Be(createdProduct.Name);

            await DeleteProduct(product.Id, token);
        }

        [Theory]
        [AutoMoqData]
        public async Task GetByName_Should_Return_Correct_Product(CreateProductDto productDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);
            var createResponse = await CreateProduct(productDto, token);
            var createdProduct = await createResponse.Content.ReadAsJsonAsync<ProductResponseDto>();

            // Act
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/products/by-name/{createdProduct.Name}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            var response = await _client.SendAsync(request);
            var product = await response.Content.ReadAsJsonAsync<ProductResponseDto>();

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            
            product.Should().NotBeNull();
            product.Name.Should().Be(createdProduct.Name);

            await DeleteProduct(product.Id, token);
        }

        [Theory]
        [AutoMoqData]
        public async Task Create_Should_Return_Created_Product(CreateProductDto productDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);

            // Act
            var createResponse = await CreateProduct(productDto, token);
            var createdProduct = await createResponse.Content.ReadAsJsonAsync<ProductResponseDto>();

            // Assert
            createResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            createdProduct.Should().NotBeNull();
            createdProduct.Name.Should().Be(productDto.Name);

            await DeleteProduct(createdProduct.Id, token);
        }

        [Theory]
        [AutoMoqData]
        public async Task Update_Should_Modify_Product(CreateProductDto productDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);
            var createResponse = await CreateProduct(productDto, token);
            var createdProduct = await createResponse.Content.ReadAsJsonAsync<ProductResponseDto>();

            var updatedProductDto = new UpdateProductDto
            {
                Name = "Updated " + createdProduct.Name,
                Price = createdProduct.Price + 10,
                Description = createdProduct.Description + " Updated",
                CategoryId = createdProduct.CategoryId
            };

            // Act
            var updateRequest = new HttpRequestMessage(HttpMethod.Put, $"/api/products/{createdProduct.Id}")
            {
                Content = updatedProductDto.ReadAsJsonContent()
            };
            updateRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            updateRequest.Headers.Add("User-Agent", "Integration-Tests");

            var updateResponse = await _client.SendAsync(updateRequest);
            var updatedProduct = await updateResponse.Content.ReadAsJsonAsync<ProductResponseDto>();

            // Assert
            updateResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            updatedProduct.Name.Should().Be(updatedProductDto.Name);
            updatedProduct.Price.Should().Be(updatedProductDto.Price);

            await DeleteProduct(updatedProduct.Id, token);
        }

        [Theory]
        [AutoMoqData]
        public async Task Delete_Should_Remove_Product(CreateProductDto productDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);
            var createResponse = await CreateProduct(productDto, token);
            var createdProduct = await createResponse.Content.ReadAsJsonAsync<ProductResponseDto>();

            // Act
            var deleteResponse = await DeleteProduct(createdProduct.Id, token);

            // Assert
            deleteResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        private async Task<HttpResponseMessage> CreateProduct(CreateProductDto productDto, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/products")
            {
                Content = productDto.ReadAsJsonContent()
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            return await _client.SendAsync(request);
        }

        private async Task<HttpResponseMessage> DeleteProduct(int id, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/products/{id}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            return await _client.SendAsync(request);
        }
    }
}
