using CatalogServiceApi.Application.DTOs.ProductAttachments;
using CatalogServiceApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogServiceApi.Application.Providers
{
    public interface IExternalServiceProvider
    {
        Task<ProductAttachmentDto> FetchAttachmentAsync(int productId, AttachmentsType type);
    }
}
