using CatalogServiceApi.Application;
using CatalogServiceApi.DataAccess;
using CatalogServiceApi.Domain;
using CatalogServiceApi.Domain.Settings;
using CatalogServiceApi.WebUi.Configurations;
using CatalogServiceApi.WebUi.Middlewares;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", false, true)
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDomainServices();
await builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddSingleton<ExternalServiceSetting>(builder.Configuration.GetJsonSection<ExternalServiceSetting>("ExternalServiceSettings"));

await builder.Services.AddApplicationServices();
//builder.Services.AddSingleton<ExternalServiceSetting>(builder.Configuration.GetJsonSection<ExternalServiceSetting>("ExternalServiceSettings"));

var identitySettings = builder.Configuration.GetJsonSection<IdentitySetting>("IdentitySettings");
builder.Services.AddSingleton<IdentitySetting>(identitySettings);

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = identitySettings.Url;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = identitySettings.Url,
            ValidateAudience = false,
            ValidAudience = identitySettings.ClientId,
            ValidateLifetime = true,

            RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
            NameClaimType = "name"

        };
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();

[ExcludeFromCodeCoverage]
public partial class Program { }