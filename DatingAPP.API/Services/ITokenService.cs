using DatingAPP.API.Database.Entity;

namespace DatingAPP.API.Services
{
  public interface ITokenService
  {
    string GenerateToken(User user);
    

  }
}