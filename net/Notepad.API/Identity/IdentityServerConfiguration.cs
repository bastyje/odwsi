using Duende.IdentityServer;
using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Validation;
using Microsoft.AspNetCore.Identity;
using Notepad.API.Services;
using Notepad.Data.DbContexts;
using ApiScope = Duende.IdentityServer.Models.ApiScope;
using Client = Duende.IdentityServer.Models.Client;
using IdentityResource = Duende.IdentityServer.Models.IdentityResource;

namespace Notepad.API.Identity;

public static class IdentityServerConfiguration
{
    public static List<ApiScope> ApiScopes => new()
    {
        new("NotepadAPI", "NotepadAPI")
    };

    public static List<Client> Clients = new()
    {
        new()
        {
            ClientId = "NotepadAngularApp",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            ClientSecrets = { new("secret".Sha256()) },
            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                "NotepadAPI"
            }
        }
    };
    
    public static List<IdentityResource> IdentityResources = new()
    {
        new IdentityResources.Profile(),
        new IdentityResources.OpenId()
    };

    public static IServiceCollection ConfigureIdentityServer(this IServiceCollection services)
    {
        services
            .AddIdentityServer()
            .AddCorsPolicyService<CorsPolicyService>()
            .AddInMemoryApiScopes(ApiScopes)
            .AddInMemoryIdentityResources(IdentityResources)
            .AddInMemoryClients(Clients)
            .AddDeveloperSigningCredential()
            .AddProfileService<ProfileService>();

        services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerValidationService>();
        services.AddTransient<IProfileService, ProfileService>();

        services
            .AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<SecurityDbContext>();
        
        return services;
    }
}
