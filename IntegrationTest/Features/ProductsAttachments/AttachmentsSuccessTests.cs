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




        

       

      


        
    }
}
