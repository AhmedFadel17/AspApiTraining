﻿using CatalogServiceApi.Domain.Enums;

namespace CatalogServiceApi.Application.DTOs.ProductAttachments
{
    public record CreateProductAttachmentsDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? BrandName { get; set; }
        public string? BrandDescription { get; set; }
        public string? BrandPhone { get; set; }
        public decimal? DiscountAmount { get; set; }
        public int? DiscountPercentage { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? MediaUrl { get; set; }
        public string? MediaType { get; set; }
    }
}
