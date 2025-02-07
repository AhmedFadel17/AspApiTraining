using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.IntegrationTest.AutoFixture;
using CatalogServiceApi.IntegrationTest.Extensions;
using FluentAssertions;
using IntegrationTest;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CatalogServiceApi.IntegrationTest.Features.Prodcuts
{
    
    public class ProductTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        public ProductTests(CustomWebApplicationFactory<Program> factory)
        {         
            _client = factory.CreateClient();
        }

        [Theory]
        [AutoMoqData]
        public async Task By_price_range_Success(CreateProductDto productDto)
        {
            //Arrange                                 
            HttpResponseMessage res = await CreateProudcut(productDto);
            res.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            //Act
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"/api/products/by-price-range?min={productDto.Price}&max={productDto.Price + 1}", System.UriKind.Relative),

                //Headers = { Authorization = token.RemoveBearerPrefix() }
            };
            request.Headers.Add("User-Agent", "Integration-Tests");
            var response = await _client.SendAsync(request);

            var products = await response.Content.ReadAsJsonAsync<List<ProductResponseDto>>();
            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            products.Count.Should().Be(1);
        }

       

        [Theory]
        [AutoMoqData]
        public async Task get_all_Success(CreateProductDto productDto)
        {
            //Arrange                                 
            HttpResponseMessage res = await CreateProudcut(productDto);
            res.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            //Act
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"/api/products", System.UriKind.Relative),

                //Headers = { Authorization = token.RemoveBearerPrefix() }
            };
            request.Headers.Add("User-Agent", "Integration-Tests");
            var response = await _client.SendAsync(request);

            var products = await response.Content.ReadAsJsonAsync<List<ProductResponseDto>>();
            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            products.Count(c=> c.Name== productDto.Name).Should().Be(1);
        }

        private async Task<HttpResponseMessage> CreateProudcut(CreateProductDto productDto)
        {
            var creatRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"/api/products", System.UriKind.Relative),
                Content = productDto.ReadAsJsonContent(),
            };
            creatRequest.Headers.Add("User-Agent", "Integration-Tests");

            var res = await _client.SendAsync(creatRequest);
            return res;
        }
    }
}
    
