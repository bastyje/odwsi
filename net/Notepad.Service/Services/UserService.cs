using Microsoft.AspNetCore.Identity;
using Notepad.Data.Repositories.Interfaces;
using Notepad.Service.Models;
using Notepad.Service.Services.Interfaces;

namespace Notepad.Service.Services;

public class UserService : IUserService
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    
    public void Register(RegisterUserModel registerUserModel)
    {
        _userManager.CreateAsync(new IdentityUser
        {
            UserName = registerUserModel.UserName,
            Email = registerUserModel.Email
        }, registerUserModel.Password);
    }
}