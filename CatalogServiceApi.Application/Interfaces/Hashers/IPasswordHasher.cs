namespace CatalogServiceApi.Application.Interfaces.Hashers
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string password);
    }
}
