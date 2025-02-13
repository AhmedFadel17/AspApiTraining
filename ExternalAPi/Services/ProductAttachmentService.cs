using ExternalAPi.Enums;
using ExternalAPi.Interfaces;
using ExternalAPi.Models;

namespace ExternalAPi.Services
{
    public class ProductAttachmentService : IAttachmentService
    {
        public async Task<ProductAttachment> FetchAttachmentsAsync(int productId, AttachmentsType type)
        {
            return type switch
            {
                AttachmentsType.Brand => await Task.FromResult(new ProductBrand
                {
                    Id = 1,
                    ProductId = productId,
                    AttachmentType = AttachmentsType.Brand,
                    BrandName = "Nike",
                    BrandDescription = "High-quality sports brand",
                    BrandPhone = "+1-234-567-890"
                }),

                AttachmentsType.Discount => await Task.FromResult(new ProductDiscount
                {
                    Id = 2,
                    ProductId = productId,
                    AttachmentType = AttachmentsType.Discount,
                    DiscountPercentage = 15,
                    ExpiryDate = DateTime.UtcNow.AddDays(10)
                }),

                AttachmentsType.Media => await Task.FromResult(new ProductMedia
                {
                    Id = 3,
                    ProductId = productId,
                    AttachmentType = AttachmentsType.Media,
                    MediaUrl = "https://example.com/product-image.jpg",
                    MediaType = "Image"
                }),

                _ => throw new ArgumentException("Invalid attachment type", nameof(type))
            };

        }
    }
}
