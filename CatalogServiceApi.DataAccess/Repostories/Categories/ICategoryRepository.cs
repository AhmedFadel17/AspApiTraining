using CatalogServiceApi.Domain.Models;

namespace CatalogServiceApi.DataAccess.Repostories.Categories
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAllCategoriesWithProductsAsync();
    }
}
