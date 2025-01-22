using Microsoft.Extensions.DependencyInjection;

namespace ExamsApi.Domain
{
    public static class Startup
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
