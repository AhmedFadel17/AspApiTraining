using CatalogServiceApi.Domain.Models;

namespace CatalogServiceApi.DataAccess.Repostories.Products
{
    public interface IProductRepository
    {
        Task<Product> GetByNameAsync(string name);
    }
}
