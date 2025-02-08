using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CatalogServiceApi.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using CatalogServiceApi.DataAccess.Repostories.Categories;
using CatalogServiceApi.DataAccess.Repostories.Products;
using CatalogServiceApi.DataAccess.Repostories;
using System.Diagnostics.CodeAnalysis;

namespace CatalogServiceApi.DataAccess
{
    [ExcludeFromCodeCoverage]
    public static class Startup
    {
        public static Task<IServiceCollection> AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("TestDb"));
            return Task.FromResult(services);
        }
    }
}
