
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Authentication
{
    public class JwtGenerator
    {
        private readonly JwtOptions jwtOptions;

        public JwtGenerator(IOptions<JwtOptions> options)
        {
            jwtOptions = options.Value;
        }
        public string GenerateToken(int userId)
        {
            var key = Encoding.UTF8.GetBytes(jwtOptions.SecretKey);

            var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}