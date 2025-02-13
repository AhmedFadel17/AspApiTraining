
namespace CatalogServiceApi.Application.DTOs.ProductAttachments
{
    public record ProductMediaAttachmentsDto : ProductAttachmentDto
    {
        public string MediaUrl { get; set; }
        public string MediaType { get; set; }
    }
}
