using CatalogServiceApi.Application;
using CatalogServiceApi.DataAccess;
using CatalogServiceApi.Domain;
using CatalogServiceApi.WebUi.Middlewares;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDomainServices();
await builder.Services.AddDataAccessServices(builder.Configuration);
await builder.Services.AddApplicationServices();
var identityUrl = builder.Configuration.GetValue<string>("IdentityUrl");
var clientId = builder.Configuration.GetValue<string>("ClientId");

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = identityUrl;
        options.Audience = "client2";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
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
