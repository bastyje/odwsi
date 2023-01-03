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
        var user = _userService.GetUser(context.UserName);
        if (user != null && _userService.VerifyPassword(user.PasswordHash, context.Password))
        {
            context.Result = new GrantValidationResult(user.Id, GrantType.ResourceOwnerPassword);
        }
        
        return Task.CompletedTask;
    }
}