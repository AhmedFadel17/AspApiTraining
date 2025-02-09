﻿using Azure;
using CatalogServiceApi.Application.DTOs.Categories;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Domain.Enums;
using CatalogServiceApi.IntegrationTest.AutoFixture;
using CatalogServiceApi.IntegrationTest.Extensions;
using CatalogServiceApi.IntegrationTest.Services;
using FluentAssertions;
using IntegrationTest;
using System.Net.Http.Headers;

namespace CatalogServiceApi.IntegrationTest.Features.Categories
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
        public async Task GetById_Should_Return_NotFound()
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);
            var nonExistentId = int.MaxValue;

            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/categories/{nonExistentId}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        [Theory]
        [AutoMoqData]
        public async Task Update_Should_Return_NotFound(UpdateCategoryDto updatedCategoryDto)
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);
            var nonExistentId = int.MaxValue;

            var request = new HttpRequestMessage(HttpMethod.Put, $"/api/categories/{nonExistentId}")
            {
                Content = updatedCategoryDto.ReadAsJsonContent()
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
        public async Task Delete_Should_Return_NotFound()
        {
            // Arrange
            string token = await _authService.GetTokenAsync(UserRole.Manager);
            var nonExistentId = int.MaxValue; 

            var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/categories/{nonExistentId}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("User-Agent", "Integration-Tests");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        
    }
}
