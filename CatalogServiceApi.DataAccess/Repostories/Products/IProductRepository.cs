using CatalogServiceApi.Domain.Models;

namespace CatalogServiceApi.DataAccess.Repostories.Products
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> GetByNameAsync(string name);
        Task<IEnumerable<Product>> GetByPriceAsync(decimal min,decimal max);

    }
}
