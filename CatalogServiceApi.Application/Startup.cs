using CatalogServiceApi.Application.Cache;
using CatalogServiceApi.Application.Interfaces.Categories;
using CatalogServiceApi.Application.Interfaces.Products;
using CatalogServiceApi.Application.Services.Categories;
using CatalogServiceApi.Application.Services.Products;
using CatalogServiceApi.Domain.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace CatalogServiceApi.Application
{
    [ExcludeFromCodeCoverage]
    public static class Startup
    {
        public static Task<IServiceCollection> AddApplicationServices(this IServiceCollection services)
        {           
         

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddMemoryCache();
            services.AddScoped<IProductAttachmentsService, ProductAttachmentsService>();
            services.AddSingleton<ICustomCache, CustomCache>();

            return Task.FromResult(services);
        }
    }
}
