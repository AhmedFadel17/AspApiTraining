using CatalogServiceApi.IdentityServer;
using CatalogServiceApi.IdentityServer.Data;
using CatalogServiceApi.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ApplicationDbContextInitialiser>();


builder.Services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();

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
    .AddInMemoryClients(Config.Clients)
    .AddApiAuthorization<ApplicationUser, AppDbContext>(op => {
        op.Clients = cl;
        op.ApiScopes = scopes;
        op.IdentityResources = identityResources;
    }).AddProfileService<ProfileService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using (var scope = app.Services.CreateScope())
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
        await initialiser.InitialiseAsync();
        await initialiser.SeedAsync();
    }
}

app.UseHttpsRedirection();

app.Run();

