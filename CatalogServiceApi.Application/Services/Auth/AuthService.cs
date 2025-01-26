using AutoMapper;
using CatalogServiceApi.Application.DTOs.Auth;
using CatalogServiceApi.Application.Interfaces.Auth;
using CatalogServiceApi.Application.Interfaces.Hashers;
using CatalogServiceApi.Application.Services.Hashers;
using CatalogServiceApi.DataAccess.Repostories.Auth;
using CatalogServiceApi.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CatalogServiceApi.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repo;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public AuthService(IAuthRepository repo,IPasswordHasher passwordHasher,IMapper mapper,IConfiguration configuration)
        {
            _repo=repo;
            _passwordHasher=passwordHasher;
            _mapper=mapper;
            _config=configuration;
        }
        public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user= await _repo.GetUserByEmailAsync(loginDto.Email);

            if (user == null || !_passwordHasher.VerifyPassword(user.Password, loginDto.Password))
            {
                throw new InvalidOperationException("Invalid email or password.");
            }

            var token = GenerateJwtToken(user);
            return _mapper.Map<AuthResponseDto>((token, user));
        }

        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            var userByEmail = await _repo.GetUserByEmailAsync(registerDto.Email);
            if (userByEmail != null) throw new InvalidOperationException("User with this email already exists.");
            var userByUsername = await _repo.GetUserByUsernameAsync(registerDto.Username);
            if (userByEmail != null) throw new InvalidOperationException("User with this username already exists.");

            var hashedPassword = _passwordHasher.HashPassword(registerDto.Password);

            var newUser = _mapper.Map<User>(registerDto);
            var user = await _repo.CreateAsync(newUser);
            await _repo.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }


        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, user.Id.ToString()),
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.Username),
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Email, user.Email)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
