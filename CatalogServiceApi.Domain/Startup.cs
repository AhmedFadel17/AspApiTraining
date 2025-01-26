using Microsoft.Extensions.DependencyInjection;

namespace CatalogServiceApi.Domain
{
    public static class Startup
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
