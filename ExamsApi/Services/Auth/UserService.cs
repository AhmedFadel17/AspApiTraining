using ExamsApi.Data;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using ExamsApi.DTOs.Auth;
using ExamsApi.Models;
using Microsoft.EntityFrameworkCore;
using ExamsApi.Services.Hashers;
namespace ExamsApi.Services.Auth
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(ApplicationDbContext context, IConfiguration configuration, IPasswordHasher passwordHasher)
        {
            _context = context;
            _configuration = configuration;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserDto> RegisterUserAsync(RegisterDto registerDto)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == registerDto.Email || u.Username == registerDto.Username);

            if (existingUser != null)
            {
                throw new InvalidOperationException("User with this email or username already exists.");
            }

            var hashedPassword = _passwordHasher.HashPassword(registerDto.Password);

            var newUser = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                Password = hashedPassword,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Id = newUser.Id,
                Username = newUser.Username,
                Email = newUser.Email,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName
            };
        }

        public async Task<AuthResponseDto> LoginUserAsync(LoginDto loginDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null || !_passwordHasher.VerifyPassword(user.Password, loginDto.Password))
            {
                throw new InvalidOperationException("Invalid email or password.");
            }

            var token = GenerateJwtToken(user);

            return new AuthResponseDto
            {
                Token = token,
                User = new UserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                }
            };
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, user.Id.ToString()),
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.Username),
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Email, user.Email)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
