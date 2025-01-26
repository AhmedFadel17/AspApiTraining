using CatalogServiceApi.Application.DTOs.Auth;

namespace CatalogServiceApi.Application.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<UserDto> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    }
}
