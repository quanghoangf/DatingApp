using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using DatingAPP.API.Database;
using DatingAPP.API.Database.Entity;
using Namespace;

namespace DatingAPP.API.Services
{
  public class UserService : IUserService
  {
    private readonly DataContext _context;

    public UserService(DataContext context)
    {
      this._context = context;
    }
    public void CreateNewUser(User user)
    {
      _context.Users.Add(user);
      _context.SaveChanges();
    }

    public void DeleteUser(User user)
    {
      _context.Users.Remove(user);
      _context.SaveChanges();
    }

    public List<User> GetListUser()
    {
      return _context.Users.ToList();
    }

    public User? GetUserById(int id)
    {
      return _context.Users.FirstOrDefault(u => u.Id == id);
    }

    public User? GetUserByUsername(string username)
    {
      return _context.Users.FirstOrDefault(u => u.Username == username);
    }

    public void UpdateUser(User user)
    {
      throw new NotImplementedException();
    }
  }
}