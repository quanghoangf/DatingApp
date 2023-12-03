using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DatingAPP.API.Database;
using DatingAPP.API.Database.Entity;

namespace DatingAPP.API.Extensions
{
  public class DataSeeder
  {
      public static void SeedData(DataContext context) {
        if(context.Users.Any()) return;
        var userJson = File.ReadAllText("Database/user.json");
        var user = JsonSerializer.Deserialize<List<User>>(userJson);
        if(user is null ||!user.Any()) return;
        var passwordBytes = Encoding.UTF8.GetBytes("Password$");
        foreach (User u in user)
        {
          using var hashFunc = new HMACSHA256();
          u.Username = u.Email;
          u.PasswordHash = hashFunc.ComputeHash(passwordBytes);
          u.PasswordSalt = hashFunc.Key;
        }
        context.Users.AddRange(user);
        context.SaveChanges();
      } 
  }
}