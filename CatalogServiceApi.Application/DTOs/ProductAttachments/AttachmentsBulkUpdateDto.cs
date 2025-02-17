using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogServiceApi.Application.DTOs.ProductAttachments
{
    public record AttachmentsBulkUpdateDto
    {
        public string Name { get; set; }
        public string NewName { get; set; }
    }
}
