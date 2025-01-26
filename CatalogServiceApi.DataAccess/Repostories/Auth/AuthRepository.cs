using CatalogServiceApi.DataAccess.Data;
using CatalogServiceApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CatalogServiceApi.DataAccess.Repostories.Auth
{
    public class AuthRepository : BaseRepository<User> ,IAuthRepository
    {
        private readonly ApplicationDbContext _context;


        public AuthRepository(ApplicationDbContext context) : base(context) { }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _dbSet
                .FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var user = await _dbSet
                .FirstOrDefaultAsync(u => u.Username == username);
            return user;
        }
    }
}
