using DatingAPP.API.Database.Entity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Namespace
{
  [Route("api/user")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
      _userService = userService;
    }
    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
      return _userService.GetListUser();
    }

    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
      var user = _userService.GetUserById(id);
      if(user is null) return NotFound();
      return Ok(user);
    }

    [HttpPost]
    public ActionResult Post([FromBody] User value)
    {
      _userService.CreateNewUser(value);
      return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] User value)
    {
      var currentUser = _userService.GetUserById(id);
      if(currentUser is null) return NotFound();
      currentUser.Username = value.Username;
      currentUser.Email = value.Email;
      return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      var currentUser = _userService.GetUserById(id);
      if(currentUser is null) return NotFound();
      _userService.DeleteUser(currentUser);
      return Ok();
    }
  }
}