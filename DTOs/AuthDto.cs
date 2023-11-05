using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAPP.API.DTOs
{
  public class AuthRegisterDto
  {
    [EmailAddress]
    [MaxLength(100)]
    public string Username { get; set; } = null!;
    [MaxLength(100)]
    public string Password { get; set; } = null!;
  }
  public class AuthLoginDto
  {
    [EmailAddress]
    [MaxLength(100)]
    public string Username { get; set; } = null!;
    [MaxLength(100)]
    public string Password { get; set; } = null!;
  }
}