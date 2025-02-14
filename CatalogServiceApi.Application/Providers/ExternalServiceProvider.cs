using AutoMapper;
using CatalogServiceApi.Application.Cache;
using CatalogServiceApi.Application.DTOs.ProductAttachments;
using CatalogServiceApi.Application.Extensions;
using CatalogServiceApi.DataAccess.Repostories.ProductAttachments;
using CatalogServiceApi.Domain.Enums;
using CatalogServiceApi.Domain.Settings;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace CatalogServiceApi.Application.Providers
{
    public class ExternalServiceProvider : IExternalServiceProvider
    {
        private readonly HttpClient _client;
        private readonly ExternalServiceSetting _settings;
        private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;
        private readonly ICustomCache _customCache;

        public ExternalServiceProvider(ExternalServiceSetting externalService,ICustomCache customCache,HttpClient httpClient)
        {
            _client = httpClient;
            _customCache = customCache;
            _settings = externalService;
            _retryPolicy = HttpPolicyExtensions
               .HandleTransientHttpError()
               .WaitAndRetryAsync(_settings.RetriesCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                   (outcome, timespan, retryCount, context) =>
                   {
                   });
        }
        public async Task<ProductAttachmentDto> FetchAttachmentAsync(int productId, AttachmentsType type)
        {
            string url = $"{_client.BaseAddress}api/Attachments/{productId}/{type.ToString()}";
            var cachedObject = _customCache.Get<ProductAttachmentDto>(url);
            if (cachedObject != null) return cachedObject;
            var response = await _retryPolicy.ExecuteAsync(async () =>
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await _client.SendAsync(request);
                return response;

            });
            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Failed to fetch attachment: {response.StatusCode} - {errorMessage}");
            }

            ProductAttachmentDto data = type switch
            {
                AttachmentsType.Brand => await response.Content.ReadAsJsonAsync<ProductBrandAttachmentsDto>(),
                AttachmentsType.Discount => await response.Content.ReadAsJsonAsync<ProductDiscountAttachmentsDto>(),
                AttachmentsType.Media => await response.Content.ReadAsJsonAsync<ProductMediaAttachmentsDto>(),
                _ => throw new InvalidOperationException("Unknown attachment type")
            };
            _customCache.Set<ProductAttachmentDto>(url, data, TimeSpan.FromSeconds(_settings.CacheInSeconds));
            return data;

        }
    }
}
