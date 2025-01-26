using CatalogServiceApi.DataAccess.Data;
using CatalogServiceApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogServiceApi.DataAccess.Repostories.Categories
{
    public class CategoriesRepository : BaseRepository<Category> , ICategoriesRepository
    {
        public CategoriesRepository(ApplicationDbContext context) : base(context) { }

        public IQueryable<Category> GetAllCategoriesWithProductsAsync()
        {
            return _dbSet.Include(c => c.Products).AsQueryable();
        }
    }
}
