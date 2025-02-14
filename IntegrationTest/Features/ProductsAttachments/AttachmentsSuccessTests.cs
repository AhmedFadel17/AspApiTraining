using Azure;
using CatalogServiceApi.Application.DTOs.ProductAttachments;
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

namespace CatalogServiceApi.IntegrationTest.Features.ProductsAttachments
{
    public class AttachmentsSuccessTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly IAuthService _authService;

        public AttachmentsSuccessTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
            using var scope = factory.Services.CreateScope();
            _authService = scope.ServiceProvider.GetRequiredService<IAuthService>();
        }


        [Theory]
        [AutoMoqData]
        public async Task GetById_Should_Return_Correct_Product(CreateProductAttachmentsDto attachmentsDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);
            var createResponse = await CreateAttachments(attachmentsDto, token);
            var createdProduct = await createResponse.Content.ReadAsJsonAsync<ProductAttachmentsResponseDto>();

            // Act
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/products/{createdProduct.ProductId}/attachments");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            var response = await _client.SendAsync(request);
            var product = await response.Content.ReadAsJsonAsync<ProductAttachmentsResponseDto>();

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            product.Should().NotBeNull();
            product.Id.Should().Be(createdProduct.Id);
            product.BrandName.Should().Be(createdProduct.BrandName);

            await DeleteAttachments(product.Id, token);
        }


        [Theory]
        [AutoMoqData]
        public async Task Create_Should_Return_Created_Product(CreateProductAttachmentsDto attachmentsDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);

            // Act
            var createResponse = await CreateAttachments(attachmentsDto, token);
            var createdProduct = await createResponse.Content.ReadAsJsonAsync<ProductAttachmentsResponseDto>();

            // Assert
            createResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            createdProduct.Should().NotBeNull();
            createdProduct.BrandName.Should().Be(attachmentsDto.BrandName);

            await DeleteAttachments(createdProduct.Id, token);
        }

        [Theory]
        [AutoMoqData]
        public async Task Delete_Should_Remove_ProductAttachment(CreateProductAttachmentsDto attachmentsDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);
            var createResponse = await CreateAttachments(attachmentsDto, token);
            var createdProduct = await createResponse.Content.ReadAsJsonAsync<ProductAttachmentsResponseDto>();

            // Act
            var deleteResponse = await DeleteAttachments(createdProduct.Id, token);

            // Assert
            deleteResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        private async Task<HttpResponseMessage> CreateAttachments(CreateProductAttachmentsDto attachmentsDto, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"/api/products/attachments")
            {
                Content = attachmentsDto.ReadAsJsonContent()
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            return await _client.SendAsync(request);
        }

        private async Task<HttpResponseMessage> DeleteAttachments(int id, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/products/{id}/attachments");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            return await _client.SendAsync(request);
        }







    }
}
