using CatalogServiceApi.Application.DTOs.ProductAttachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogServiceApi.Application.Interfaces.Products
{
    public interface IProductAttachmentsService
    {
        Task<ProductAttachmentsResponseDto> GetProductAttachments(int id);
    }
}
