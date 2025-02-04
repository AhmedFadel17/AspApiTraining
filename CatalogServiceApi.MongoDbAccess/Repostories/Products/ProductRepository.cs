using CatalogServiceApi.Domain.MongoModels;
using MongoDB.Driver;

namespace CatalogServiceApi.MongoDbAccess.Repostories.Products
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IMongoDatabase database)
            : base(database, "Products") { }
        public async Task<Product> GetByNameAsync(string name)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Name, name);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetByPriceAsync(decimal minFrom, decimal maxFrom, decimal minTo, decimal maxTo)
        {
            var filter = Builders<Product>.Filter.ElemMatch(p => p.Prices, price =>
                    price.From >= minFrom && price.From <= maxFrom && price.To >= minTo && price.To <= maxTo
                );
            return await _collection.Find(filter).ToListAsync();
        }

    }
}
