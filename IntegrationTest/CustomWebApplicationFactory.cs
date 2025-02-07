using CatalogServiceApi.DataAccess.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
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
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
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
    