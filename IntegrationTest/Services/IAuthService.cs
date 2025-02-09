using CatalogServiceApi.Domain.Enums;

namespace CatalogServiceApi.IntegrationTest.Services
{
    public interface IAuthService
    {
        Task<string> GetTokenAsync(UserRole role);
    }
}