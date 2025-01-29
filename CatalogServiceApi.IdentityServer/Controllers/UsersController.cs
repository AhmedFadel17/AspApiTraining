using CatalogServiceApi.IdentityServer.Data;
using Duende.IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CatalogServiceApi.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UsersController(AppDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUser model)
        {
            await TrySeedAsync(model);
            return Ok();
        }

        public async Task TrySeedAsync(ApplicationUser administrator)
        {
            // Default roles
            var administratorRole = new IdentityRole("manager");
            var memberRole = new IdentityRole("store");
            var customerRole = new IdentityRole("customer");


            if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await _roleManager.CreateAsync(administratorRole);
                await _roleManager.CreateAsync(customerRole);

                await _roleManager.CreateAsync(memberRole);
            }

            if (_userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await _userManager.CreateAsync(administrator, "Administrator1!");
                await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
                await _userManager.AddToRolesAsync(administrator, new[] { customerRole.Name });
                await _userManager.AddToRolesAsync(administrator, new[] { memberRole.Name });



                await _userManager.AddClaimsAsync(administrator, new Claim[] {
                    new Claim(JwtClaimTypes.Name, "Bob Smith"),
                    new Claim(JwtClaimTypes.GivenName,""),
                    new Claim("location", "somewhere")
                });
            }
        }
    }
}
