using CatalogServiceApi.Domain.Models;

namespace CatalogServiceApi.DataAccess.Repostories.Auth
{
    public interface IAuthRepository
    {
        Task RegisterAsync(User user);
        Task<User>? GetUserAsync(string email);
        string GenerateJwtToken(User user);
    }
}
