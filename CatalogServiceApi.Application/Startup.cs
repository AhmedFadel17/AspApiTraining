using CatalogServiceApi.Application.Interfaces.Auth;
using CatalogServiceApi.Application.Interfaces.Categories;
using CatalogServiceApi.Application.Interfaces.Hashers;
using CatalogServiceApi.Application.Interfaces.Products;
using CatalogServiceApi.Application.Services.Auth;
using CatalogServiceApi.Application.Services.Categories;
using CatalogServiceApi.Application.Services.Hashers;
using CatalogServiceApi.Application.Services.Products;
using CatalogServiceApi.IdentityServer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogServiceApi.Application
{
    public static class Startup
    {
        public static Task<IServiceCollection> AddApplicationServices(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICategoryServices, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return Task.FromResult(services);
        }
    }
}
