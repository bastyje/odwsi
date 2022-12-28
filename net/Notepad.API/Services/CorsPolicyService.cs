using Duende.IdentityServer.Services;

namespace Notepad.API.Services;

public class CorsPolicyService : ICorsPolicyService
{
    public Task<bool> IsOriginAllowedAsync(string origin)
    {
        return Task.FromResult(true);
    }
}