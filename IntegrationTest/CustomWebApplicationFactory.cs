using CatalogServiceApi.DataAccess.Data;
using CatalogServiceApi.Domain.Settings;
using CatalogServiceApi.IntegrationTest.Services;
using CatalogServiceApi.WebUi.Configurations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IntegrationTest;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");
        builder.ConfigureServices(services =>
        {
        var serviceProvider = services.BuildServiceProvider();
        var conf = serviceProvider.GetRequiredService<IConfiguration>();
        var identitySettings = conf.GetJsonSection<IdentitySetting>("IdentitySettings");
            services.AddMemoryCache();

            services.AddSingleton<IAuthService>(sp =>
            {
                var memoryCache = sp.GetRequiredService<IMemoryCache>();
                return new AuthService(identitySettings, memoryCache);
            }); var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
            if (descriptor != null)
                services.Remove(descriptor);                     

            services
            .AddEntityFrameworkInMemoryDatabase()
            .AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseInMemoryDatabase("TestDb").UseInternalServiceProvider(sp);
            });
            
        });
    }
}
    