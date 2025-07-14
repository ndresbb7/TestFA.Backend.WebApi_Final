namespace TestFA.Backend.WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using TestFA.Backend.WebApi.Authorization;
using TestFA.Backend.WebApi.Models;
using TestFA.Backend.WebApi.Interfaces;

[ApiController]
[Authorize]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }
}
