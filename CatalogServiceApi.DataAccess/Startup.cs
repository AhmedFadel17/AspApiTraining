using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CatalogServiceApi.DataAccess.Data;
using CatalogServiceApi.DataAccess.Repostories.Categories;
using CatalogServiceApi.DataAccess.Repostories.Products;
using CatalogServiceApi.DataAccess.Repostories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CatalogServiceApi.DataAccess
{
    public static class Startup
    {
        public static Task<IServiceCollection> AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMongoClient>(sp =>
            {
                var mongoConnectionString = configuration.GetConnectionString("MongoDbConnectionString");
                return new MongoClient(mongoConnectionString); // Make sure the connection string is correctly set in appsettings.json
            });

            services.AddSingleton(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase("CatalogServiceDb"); // Specify the correct database name
            });
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            

            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return Task.FromResult(services);
        }
    }
}
