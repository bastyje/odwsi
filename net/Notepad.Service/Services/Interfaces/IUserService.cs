using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Notepad.Data.Entities;
using Notepad.Service.Models;

namespace Notepad.Service.Services.Interfaces;

public interface IUserService
{
    ServiceMessage Register(RegisterUserModel registerUserModel);
    ApplicationUser GetUser(string username);
    bool VerifyPassword(string dbPassword, string enteredPassword);
}