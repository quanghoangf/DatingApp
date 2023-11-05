
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAPP.API.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace DatingAPP.API.Database
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<User> Users {get; set;} = null!;
  }
}