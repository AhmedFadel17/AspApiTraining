using CatalogServiceApi.Application.DTOs.Errors;
using CatalogServiceApi.WebUi.Validators;

namespace CatalogServiceApi.WebUi.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (string.IsNullOrEmpty(token))
            {
                await HandleAuthAsync(context, "Token is missing");
                return;
            }
            var validator = new JwtTokenValidator(_configuration);
            var (isValid, errorMessage, userClaims) = validator.ValidateToken(token);

            if (!isValid)
            {
                await HandleAuthAsync(context, errorMessage);
                return;
            }

            context.User = userClaims;
            await _next(context);

        }

        private static Task HandleAuthAsync(HttpContext context,string msg="Unauthorized")
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;

            var response = new ErrorResponseDto
            {
                Error = msg,
                StatusCode = context.Response.StatusCode,
                Details = null
            };

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
