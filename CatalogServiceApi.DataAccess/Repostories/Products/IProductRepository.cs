using CatalogServiceApi.Domain.Models;

namespace CatalogServiceApi.DataAccess.Repostories.Products
{
    public interface IProductsRepository
    {
        Task<Product> GetByNameAsync(string name);
    }
}
