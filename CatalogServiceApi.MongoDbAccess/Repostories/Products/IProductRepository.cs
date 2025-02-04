using CatalogServiceApi.Domain.MongoModels;

namespace CatalogServiceApi.MongoDbAccess.Repostories.Products
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> GetByNameAsync(string name);
        Task<IEnumerable<Product>> GetByPriceAsync(decimal minFrom, decimal maxFrom, decimal minTo, decimal maxTo);
    }
}
