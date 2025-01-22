using ExamsApi.Application.DTOs.Auth;

namespace ExamsApi.Application.Interfaces.Auth
{
    public interface IUserService
    {
        Task<UserDto> RegisterUserAsync(RegisterDto registerDto);
        Task<AuthResponseDto> LoginUserAsync(LoginDto loginDto);
    }
}
