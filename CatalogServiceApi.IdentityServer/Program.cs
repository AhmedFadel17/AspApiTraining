using CatalogServiceApi.IdentityServer;
using CatalogServiceApi.IdentityServer.Data;
using CatalogServiceApi.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("DefaultConnection"));


//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


var cl = new Microsoft.AspNetCore.ApiAuthorization.IdentityServer.ClientCollection();
cl.AddRange(Config.Clients.ToArray());
var scopes = new Microsoft.AspNetCore.ApiAuthorization.IdentityServer.ApiScopeCollection();
scopes.AddRange(Config.ApiScopes.ToArray());
var identityResources = new Microsoft.AspNetCore.ApiAuthorization.IdentityServer.IdentityResourceCollection();
identityResources.AddRange(Config.IdentityResources.ToArray());
builder.Services.AddIdentityServer(options =>
        {
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseInformationEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseSuccessEvents = true;

            // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
            options.EmitStaticAudienceClaim = true;
        })
     .AddInMemoryIdentityResources(Config.IdentityResources)
     .AddInMemoryApiScopes(Config.ApiScopes)
     .AddAspNetIdentity<IdentityUser>()
    .AddInMemoryClients(Config.Clients)
    .AddProfileService<ProfileService>();






async Task SeedDataAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
{
    var roles = new[] { UserRole.Manager.ToString(), UserRole.Store.ToString(), UserRole .Customer.ToString()};

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    var adminEmail = "admin@example.com";
    var adminPassword = "Admin@123";

    if (await userManager.FindByEmailAsync(adminEmail) == null)
    {
        var adminUser = new IdentityUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true  // 👈 Ensure EmailConfirmed is true
        };

        var result = await userManager.CreateAsync(adminUser, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, roles[0]);
            await userManager.AddToRoleAsync(adminUser, roles[1]);
            await userManager.AddClaimAsync(adminUser, new Claim("role", roles[0]));
            await userManager.AddClaimAsync(adminUser, new Claim("role", roles[1]));
        }
        else
        {
            Console.WriteLine($"Failed to create admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }
}





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using (var scope = app.Services.CreateScope())
    {
        var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if (_context.Database.IsSqlServer())
        {
            await _context.Database.MigrateAsync();
        }

        var serviceProvider = scope.ServiceProvider;
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        await SeedDataAsync(userManager, roleManager);
    }
}

app.UseHttpsRedirection();
app.UseIdentityServer();
app.Run();

