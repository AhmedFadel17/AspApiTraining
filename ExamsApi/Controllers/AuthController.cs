using ExamsApi.Application.Interfaces.Auth;
using ExamsApi.Application.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;

namespace ExamsApi.WebUi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
        {
            var authResponse = await _userService.LoginUserAsync(loginDto);
            return Ok(authResponse);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var user = await _userService.RegisterUserAsync(registerDto);
            return Ok(user);
        }
    }
}
