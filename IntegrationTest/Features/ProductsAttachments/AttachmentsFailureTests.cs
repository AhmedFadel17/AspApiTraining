using Azure;
using CatalogServiceApi.Application.DTOs.ProductAttachments;
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
    public class AttachmentsFailureTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly IAuthService _authService;

        public AttachmentsFailureTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
            using var scope = factory.Services.CreateScope();
            _authService = scope.ServiceProvider.GetRequiredService<IAuthService>();
        }


        //[Theory]
        //[AutoMoqData]
        //public async Task GetById_Should_Return_NotFound_When_Product_Does_Not_Exist(CreateProductAttachmentsDto attachmentsDto)
        //{
        //    // Arrange
        //    string token = await _authService.GetTokenAsync(UserRole.Manager);
        //    var nonExistentProductId = int.MaxValue;

        //    var request = new HttpRequestMessage(HttpMethod.Get, $"/api/products/{nonExistentProductId}/attachments");
        //    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //    request.Headers.Add("User-Agent", "Integration-Tests");

        //    // Act
        //    var response = await _client.SendAsync(request);

        //    // Assert
        //    response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        //}

        [Theory]
        [AutoMoqData]
        public async Task Delete_Should_Return_NotFound_When_Product_Attachments_Does_Not_Exist()
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);
            var nonExistentProductId = int.MaxValue; 

            var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/products/{nonExistentProductId}/attachments");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        
    }
}
