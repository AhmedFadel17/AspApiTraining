using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogServiceApi.Application
{
    public static class Startup
    {
        public static Task<IServiceCollection> AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            return Task.FromResult(services);
        }
    }
}
