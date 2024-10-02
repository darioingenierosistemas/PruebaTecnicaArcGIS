using ArcGISApi.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ArcGISApi.Services
{
    public class JwtAuthService : IJwtAuthService
    {
        private readonly string _secretKey = "EsriEvolutionSuperSecureSecretKey12345";

        public string GenerateToken(string username, string password)
        {
            if (username == "@Dario" && password == "Esri1234")
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_secretKey);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username)
                }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Audience = "Evolution",
                    Issuer = username


                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }

            return null;
        }

        public async Task<bool> ValidateToken(HttpContext context)
        {
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (authHeader == null)
            {
                return false;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey);

            try
            {
                tokenHandler.ValidateToken(authHeader, new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true,  
                    ValidateAudience = true,  
                    ValidateIssuer = true,    
                    ValidIssuer = "@Dario",   
                    ValidAudience = "Evolution",
                }, out SecurityToken validatedToken);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
