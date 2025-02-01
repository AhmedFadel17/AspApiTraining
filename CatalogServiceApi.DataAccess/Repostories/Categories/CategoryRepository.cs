using CatalogServiceApi.DataAccess.Data;
using CatalogServiceApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace CatalogServiceApi.DataAccess.Repostories.Categories
{
    public class CategoryRepository : BaseRepository<Category> , ICategoryRepository
    {

        public CategoryRepository(IMongoDatabase database) : base(database, "Categories")
        {
        }

        public IQueryable<Category> GetAllCategoriesWithProductsAsync()
        {
            return _collection.AsQueryable();
        }

    
    }
}
