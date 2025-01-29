using AutoMapper;
using CatalogServiceApi.Application.DTOs.Auth;
using CatalogServiceApi.Application.Interfaces.Auth;
using CatalogServiceApi.Application.Interfaces.Hashers;
using CatalogServiceApi.IdentityServer.Data;
using Microsoft.AspNetCore.Identity;


namespace CatalogServiceApi.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper=mapper;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
                throw new InvalidOperationException("Invalid email or password.");

            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);

            if (!result.Succeeded)
                throw new InvalidOperationException("Invalid email or password.");

            var token = "messi";
            return _mapper.Map<AuthResponseDto>((token, user));
        }

        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            var userByEmail = await _userManager.FindByEmailAsync(registerDto.Email);
            if (userByEmail != null) throw new InvalidOperationException("User with this email already exists.");
            var userByUsername = await _userManager.FindByNameAsync(registerDto.Username);
            if (userByEmail != null) throw new InvalidOperationException("User with this username already exists.");

            var newUser = _mapper.Map<ApplicationUser>(registerDto);
            var user = await _userManager.CreateAsync(newUser, registerDto.Password);
            return _mapper.Map<UserDto>(user);
        }

    }
}
