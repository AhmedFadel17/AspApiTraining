using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogServiceApi.Application.DTOs.ProductAttachments
{
    public record AttachmentsBulkDeleteDto
    {
        public string Name { get; set; }
    }
}
