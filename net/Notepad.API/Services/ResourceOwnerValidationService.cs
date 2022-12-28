using System.Security.Claims;
using Duende.IdentityServer.Validation;
using Notepad.Data.Repositories.Interfaces;

namespace Notepad.API.Services;

public class ResourceOwnerValidationService : IResourceOwnerPasswordValidator
{
    private readonly IUserRepository _userRepository;

    public ResourceOwnerValidationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    {
        var user = _userRepository.GetUserByUsername(context.UserName);
        context.Result = new GrantValidationResult(subject: "123", authenticationMethod: "custom");
        return Task.CompletedTask;
    }
}