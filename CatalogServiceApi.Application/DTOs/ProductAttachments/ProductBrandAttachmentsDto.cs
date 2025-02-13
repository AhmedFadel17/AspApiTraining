using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogServiceApi.Application.DTOs.ProductAttachments
{
    public record ProductBrandAttachmentsDto : ProductAttachmentDto
    {
        public string BrandName { get; set; }
        public string BrandDescription { get; set; }
        public string BrandPhone { get; set; }
    }
}
