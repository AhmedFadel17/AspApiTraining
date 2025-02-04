using CatalogServiceApi.Domain.MongoModels;
using MongoDB.Driver;

namespace CatalogServiceApi.MongoDbAccess.Repostories.Categories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IMongoDatabase database) : base(database, "Categories")
        {
        }
    }
}
