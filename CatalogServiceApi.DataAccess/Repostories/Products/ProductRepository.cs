using CatalogServiceApi.DataAccess.Data;
using CatalogServiceApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogServiceApi.DataAccess.Repostories.Products
{
    public class ProductsRepository : BaseRepository<Product>, IProductsRepository
    {
        public ProductsRepository(ApplicationDbContext context) : base(context){}

        public async Task<Product> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(e => EF.Property<string>(e, "Name") == name);
        }

    }
}
