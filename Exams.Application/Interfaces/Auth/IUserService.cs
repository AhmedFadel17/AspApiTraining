using ExamsApi.Application.DTOs.Auth;

namespace ExamsApi.Application.Interfaces.Auth
{
    public interface IUserService
    {
        Task<UserDto> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    }
}
