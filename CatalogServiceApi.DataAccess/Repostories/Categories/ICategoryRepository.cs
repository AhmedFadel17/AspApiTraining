using CatalogServiceApi.Domain.Models;

namespace CatalogServiceApi.DataAccess.Repostories.Categories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        IQueryable<Category> GetAllCategoriesWithProductsAsync();
    }
}
