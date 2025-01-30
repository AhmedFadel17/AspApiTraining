using CatalogServiceApi.IdentityServer.Data;
using CatalogServiceApi.IdentityServer.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CatalogServiceApi.IdentityServer.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Create([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, UserRole.Manager.ToString());
                await _userManager.AddClaimAsync(user, new Claim("role", UserRole.Manager.ToString()));
                return Ok(new { Message = "User registered successfully" });
            }

            return BadRequest(result.Errors);
        }

       
    }
}
