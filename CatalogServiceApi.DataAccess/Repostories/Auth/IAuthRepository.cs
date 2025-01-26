using CatalogServiceApi.Domain.Models;

namespace CatalogServiceApi.DataAccess.Repostories.Auth
{
    public interface IAuthRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByUsernameAsync(string username);
    }
}
