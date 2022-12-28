using Microsoft.AspNetCore.Mvc;
using Notepad.Data.Repositories.Interfaces;
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
    
    [HttpPut]
    public ActionResult Register([FromBody] RegisterUserModel registerUserModel)
    {
        _userService.Register(registerUserModel);
        return new OkResult();
    }
}