using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAPP.API.Database.Entity
{
  public class User
  {
    [Key]
    public int Id {get; set;}
    [StringLength(100)]
    public string Username {get;set;} = null!;
    [StringLength(255)]
    public string Email {get; set;} = null!;
    public byte[] PasswordHash { get; set; } = null!;
    public byte[] PasswordSalt { get; set; } = null!;

  }
}