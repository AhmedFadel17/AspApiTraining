using CatalogServiceApi.Domain.Enums;

namespace CatalogServiceApi.Application.DTOs.ProductAttachments

{
    public record ProductAttachmentDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public AttachmentsType AttachmentType { get; set; }
    }
}
