using CatalogServiceApi.Application.Interfaces.Categories;
using CatalogServiceApi.Application.Interfaces.Products;
using CatalogServiceApi.Application.Services.Categories;
using CatalogServiceApi.Application.Services.Products;

using Microsoft.Extensions.DependencyInjection;

namespace CatalogServiceApi.Application
{
    public static class Startup
    {
        public static Task<IServiceCollection> AddApplicationServices(this IServiceCollection services)
        {           
         

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            return Task.FromResult(services);
        }
    }
}
