using CatalogServiceApi.Application.DTOs.Auth;
using CatalogServiceApi.Application.Interfaces.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CatalogServiceApi.WebUi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
        {
            var authResponse = await _authService.LoginAsync(loginDto);
            return Ok(authResponse);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var user = await _authService.RegisterAsync(registerDto);
            return Ok(user);
        }
    }
}
