using ExamsApi.Domain.Models;

namespace ExamsApi.DataAccess.Repositories.Auth
{
    public interface IUserRepository
    {
        Task RegisterAsync(User user);
        Task<User>? GetUserAsync(string email);
        string GenerateJwtToken(User user);
    }
}
