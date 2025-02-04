using CatalogServiceApi.Application.Interfaces.Categories;
using CatalogServiceApi.Application.Interfaces.Products;
using CatalogServiceApi.Application.Services.Categories;
using CatalogServiceApi.Application.Services.Products;
using CatalogServiceApi.Application.MongoServices.Products;
using CatalogServiceApi.Application.MongoServices.Categories;

using Microsoft.Extensions.DependencyInjection;

namespace CatalogServiceApi.Application
{
    public static class Startup
    {
        public static Task<IServiceCollection> AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddScoped<ICategoryServices, Services.Categories.CategoryService>();
            //services.AddScoped<IProductService, Services.Products.ProductService>();
            services.AddScoped<ICategoryServices, MongoServices.Categories.CategoryService>();
            services.AddScoped<IProductService, MongoServices.Products.ProductService>();
            return Task.FromResult(services);
        }
    }
}
