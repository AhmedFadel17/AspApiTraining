using CatalogServiceApi.Application.DTOs.Errors;
using CatalogServiceApi.WebUi.Validators;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
            var authorizeAttributes = context.GetEndpoint()?.Metadata
                    .OfType<AuthorizeAttribute>()
                    .FirstOrDefault();

            if (authorizeAttributes != null && authorizeAttributes.Roles != null)
            {
                var requiredRoles = authorizeAttributes.Roles.Split(',');

                if (!HasRequiredRole(userClaims, requiredRoles))
                {
                    await HandleAuthAsync(context, "You do not have the required role");
                    return;
                }
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

        private bool HasRequiredRole(ClaimsPrincipal userClaims, string[] requiredRoles)
        {
            foreach (var role in requiredRoles)
            {
                if (userClaims.IsInRole(role))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
