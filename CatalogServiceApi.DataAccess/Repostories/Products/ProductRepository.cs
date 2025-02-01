using CatalogServiceApi.DataAccess.Data;
using CatalogServiceApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace CatalogServiceApi.DataAccess.Repostories.Products
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

    }
}
