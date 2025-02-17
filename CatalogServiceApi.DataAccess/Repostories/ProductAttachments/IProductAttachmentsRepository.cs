using CatalogServiceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogServiceApi.DataAccess.Repostories.ProductAttachments
{
    public interface IProductAttachmentsRepository : IBaseRepository<ProductAttachment>
    {
        Task<IEnumerable<ProductAttachment>> GetByBrandNameLinqAsync(string name);
        Task<IEnumerable<ProductAttachment>> GetByBrandNameDLinqAsync(string name);
        Task<IEnumerable<ProductAttachment>> GetByBrandNameDEAsync(string name);
        Task<IEnumerable<ProductAttachment>> GetByBrandNameEMAsync(string name);
        Task<IEnumerable<ProductAttachment>> GetAllWithFiltersAsync(string name,string productName,decimal minProductPrice,int minDiscount,string categoryName);
        Task<ProductAttachment> GetByIdWithProductAsync(int id);
    }
}
