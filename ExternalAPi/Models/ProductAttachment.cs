using ExternalAPi.Enums;

namespace ExternalAPi.Models
{
    public record ProductAttachment
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public AttachmentsType AttachmentType { get; set; }
    }
}
