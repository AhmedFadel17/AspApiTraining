using ExamsApi.DTOs.Auth;

namespace ExamsApi.Services.Auth
{
    public interface IUserService
    {
        Task<UserDto> RegisterUserAsync(RegisterDto registerDto);
        Task<AuthResponseDto> LoginUserAsync(LoginDto loginDto);
    }
}
