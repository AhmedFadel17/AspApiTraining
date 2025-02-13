using ExternalAPi.Enums;
using ExternalAPi.Models;

namespace ExternalAPi.Interfaces
{
    public interface IAttachmentService
    {
        Task<ProductAttachment> FetchAttachmentsAsync(int productId,AttachmentsType type);
    }
}
