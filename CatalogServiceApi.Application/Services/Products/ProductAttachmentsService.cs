using AutoMapper;
using CatalogServiceApi.Application.Cache;
using CatalogServiceApi.Application.DTOs.ProductAttachments;
using CatalogServiceApi.Application.Extensions;
using CatalogServiceApi.Application.Interfaces.Products;
using CatalogServiceApi.DataAccess.Repostories.ProductAttachments;
using CatalogServiceApi.Domain.Enums;
using CatalogServiceApi.Domain.Models;
using CatalogServiceApi.Domain.Settings;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace CatalogServiceApi.Application.Services.Products
{
    public class ProductAttachmentsService : IProductAttachmentsService
    {
        private readonly HttpClient _client;
        private readonly ExternalServiceSetting _settings;
        private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;
        private readonly IProductAttachmentsRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICustomCache _customCache;

        public ProductAttachmentsService(ExternalServiceSetting externalService,  IProductAttachmentsRepository repository,IMapper mapper,ICustomCache customCache)
        {
            _client = new HttpClient();
            _settings = externalService;
            _mapper= mapper;
            _repository = repository;
            _customCache = customCache;

            // Polly Retry Policy (Exponential Backoff)
            _retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(_settings.RetriesCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (outcome, timespan, retryCount, context) =>
                    {
                    });
        }

        public async Task<ProductAttachmentsResponseDto> GetProductAttachments(int productId)
        {
            var attachmentTypes = new List<AttachmentsType>
            {
                AttachmentsType.Brand,
                AttachmentsType.Discount,
                AttachmentsType.Media
            };

            var tasks = new List<Task<ProductAttachmentDto>>();

            foreach (var type in attachmentTypes)
            {
                tasks.Add(FetchAttachmentAsync(productId, type));
            }

            var results = await Task.WhenAll(tasks);
            var brandDto = results.FirstOrDefault(r => r.AttachmentType == AttachmentsType.Brand) as ProductBrandAttachmentsDto;
            var discountDto = results.FirstOrDefault(r => r.AttachmentType == AttachmentsType.Discount) as ProductDiscountAttachmentsDto;
            var mediaDto = results.FirstOrDefault(r => r.AttachmentType == AttachmentsType.Media) as ProductMediaAttachmentsDto;

            var attachment = _mapper.Map<ProductAttachment>((productId,brandDto, discountDto, mediaDto));

            var createdAttachment = await _repository.CreateAsync(attachment);
            return _mapper.Map<ProductAttachmentsResponseDto>(createdAttachment);
        }

        private async Task<ProductAttachmentDto> FetchAttachmentAsync(int productId, AttachmentsType type)
        {
            string url = $"{_settings.Url}/api/Attachments/{productId}/{type.ToString()}";
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
