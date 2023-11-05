using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DatingAPP.API.Database.Entity;
using Microsoft.IdentityModel.Tokens;

namespace DatingAPP.API.Services
{
  public class TokenService : ITokenService
  {
    private readonly string _JwtSecretKey;

    public TokenService(IConfiguration configuration)
    {
      _JwtSecretKey = configuration["JwtSecretKey"] ?? string.Empty;
    }
    public string GenerateToken(User user)
    {
      var claims = new List<Claim>()
      {
        new (JwtRegisteredClaimNames.NameId, user.Username),
        new (JwtRegisteredClaimNames.Email, user.Email),
      };

      var symmetricKy = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JwtSecretKey));

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(1),
        SigningCredentials = new (symmetricKy, SecurityAlgorithms.HmacSha256Signature)
      };

      var tokenHandler = new JwtSecurityTokenHandler();

      var token = tokenHandler.CreateToken(tokenDescriptor);

      return tokenHandler.WriteToken(token);
    }
  }
}