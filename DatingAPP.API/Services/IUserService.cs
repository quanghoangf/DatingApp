

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAPP.API.Database.Entity;

namespace Namespace
{
  public interface IUserService
  {
    List<User> GetListUser();
    User? GetUserById(int id);
    User? GetUserByUsername(string username);
    void CreateNewUser(User user);
    void DeleteUser(User user);
    void UpdateUser(User user);
  }
}