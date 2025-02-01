using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CatalogServiceApi.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using CatalogServiceApi.DataAccess.Repostories.Categories;
using CatalogServiceApi.DataAccess.Repostories.Products;
using CatalogServiceApi.DataAccess.Repostories;

namespace CatalogServiceApi.DataAccess
{
    public static class Startup
    {
        public static Task<IServiceCollection> AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return Task.FromResult(services);
        }
    }
}
