using CatalogServiceApi.MongoDbAccess.Data;
using CatalogServiceApi.MongoDbAccess.Repostories;
using CatalogServiceApi.MongoDbAccess.Repostories.Categories;
using CatalogServiceApi.MongoDbAccess.Repostories.Products;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace CatalogServiceApi.MongoDbAccess
{
    public static class Startup
    {
        public static Task<IServiceCollection> AddMongoDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMongoClient>(sp =>
            {
                var mongoConnectionString = configuration.GetConnectionString("MongoDbConnectionString");
                return new MongoClient(mongoConnectionString);
            });

            services.AddSingleton(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase("CatalogServiceDb");
            });
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return Task.FromResult(services);
        }
    }
}
