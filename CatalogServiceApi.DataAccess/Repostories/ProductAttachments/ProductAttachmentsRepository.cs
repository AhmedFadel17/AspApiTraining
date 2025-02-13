using CatalogServiceApi.DataAccess.Data;
using CatalogServiceApi.Domain.Models;

namespace CatalogServiceApi.DataAccess.Repostories.ProductAttachments
{
    public class ProductAttachmentsRepository : BaseRepository<ProductAttachment>, IProductAttachmentsRepository
    {
        public ProductAttachmentsRepository(ApplicationDbContext context) : base(context) { }
    }
}
