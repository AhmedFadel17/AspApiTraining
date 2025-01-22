namespace ExamsApi.Application.DTOs.Auth
{
    public record AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public UserDto User { get; set; } = new UserDto();
    }
}
