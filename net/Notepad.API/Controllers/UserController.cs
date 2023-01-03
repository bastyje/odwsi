using Microsoft.AspNetCore.Mvc;
using Notepad.Service.Models;
using Notepad.Service.Services.Interfaces;

namespace Notepad.API.Controllers;

[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    public ActionResult Register([FromBody] RegisterUserModel registerUserModel)
    {
        var serviceMessage = _userService.Register(registerUserModel);
        return new OkObjectResult(serviceMessage);
    }

    [HttpGet]
    public ActionResult Get()
    {
        var username = User.Claims.FirstOrDefault(c => c.ValueType == "username").Value;
        return new OkObjectResult(_userService.GetUser(username));
    }
}