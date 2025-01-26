using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CatalogServiceApi.WebUi.Validators
{
    public class JwtTokenValidator
    {
        private readonly IConfiguration _config;
        public JwtTokenValidator(IConfiguration configuration)
        {
            _config = configuration;
        }

        public (bool IsValid, string ErrorMessage, ClaimsPrincipal UserClaims) ValidateToken(string token)
        {
            try
            {
                var jwtSettings = _config.GetSection("JwtSettings");
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Convert.FromBase64String(jwtSettings["Secret"]);

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false, 
                    ClockSkew = TimeSpan.Zero 
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

                if (validatedToken is JwtSecurityToken jwtToken)
                {
                    if (!jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return (false, "Invalid token algorithm", null);
                    }
                }

                return (true, null, principal);
            }
            catch (SecurityTokenExpiredException)
            {
                return (false, "Token has expired", null);
            }
            catch (Exception ex)
            {
                return (false, $"Token validation failed: {ex.Message}", null);
            }
        }
    }
}
