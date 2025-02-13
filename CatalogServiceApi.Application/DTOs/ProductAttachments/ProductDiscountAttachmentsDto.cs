using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogServiceApi.Application.DTOs.ProductAttachments
{
    public record ProductDiscountAttachmentsDto : ProductAttachmentDto
    {
        public decimal? DiscountAmount { get; set; }
        public int? DiscountPercentage { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
