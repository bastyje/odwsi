using System.Security.Claims;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Validation;
using Notepad.Data.Repositories.Interfaces;
using Notepad.Service.Services.Interfaces;

namespace Notepad.API.Services;

public class ResourceOwnerValidationService : IResourceOwnerPasswordValidator
{
    private readonly IUserService _userService;

    public ResourceOwnerValidationService(IUserService userService)
    {
        _userService = userService;
    }
    
    public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    {
        Thread.Sleep(2000);
        var user = _userService.GetUser(context.UserName);
        if (user != null && user.LockoutEnd < DateTime.Now)
        {
            if (_userService.VerifyPassword(user.PasswordHash, context.Password))
            {
                context.Result = new GrantValidationResult(user.Id, GrantType.ResourceOwnerPassword);
            }
            else
            {
                _userService.ReportFailedLogin(user.Id);
            }
        }

        return Task.CompletedTask;
    }
}