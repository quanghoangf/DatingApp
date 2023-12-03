using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DatingAPP.API.Database.Entity;
using DatingAPP.API.DTOs;
using DatingAPP.API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Namespace
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;

    public AuthController(IUserService userService, ITokenService tokenService)
    {
      _userService = userService;
      _tokenService = tokenService;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] AuthRegisterDto registerUser)
    {
      registerUser.Username = registerUser.Username.ToLower();

      var findUser = _userService.GetUserByUsername(registerUser.Username);
      if (findUser is not null)
      {
        return BadRequest("Username already registered");
      }

      using var hashFunc = new HMACSHA256();
      var passwordByte = Encoding.UTF8.GetBytes(registerUser.Password);

      var newUser = new User
      {
        Username = registerUser.Username,
        Email = registerUser.Username,
        PasswordHash = hashFunc.ComputeHash(passwordByte),
        PasswordSalt = hashFunc.Key
      };

      _userService.CreateNewUser(newUser);
      return Ok(_tokenService.GenerateToken(newUser));
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] AuthLoginDto loginUser)
    {
      loginUser.Username = loginUser.Username.ToLower();
      var findUser = _userService.GetUserByUsername(loginUser.Username);
      if (findUser is null)
      {
        return Unauthorized("User not found");
      }
      using var hashFunc = new HMACSHA256(findUser.PasswordSalt);
      var passwordByte = Encoding.UTF8.GetBytes(loginUser.Password);
      var passwordHash = hashFunc.ComputeHash(passwordByte);
      for (int i = 0; i < passwordHash.Length; i++)
      {
        if (passwordHash[i] != findUser.PasswordHash[i])
          return Unauthorized("Password Fault");
      }
      return Ok(_tokenService.GenerateToken(findUser));
    }
  }
}