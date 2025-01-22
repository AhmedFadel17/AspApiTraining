using ExamsApi.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ExamsApi.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
namespace ExamsApi.DataAccess
{
    public static class Startup
    {
        public static Task<IServiceCollection> AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return Task.FromResult(services);
        }
    }
}
