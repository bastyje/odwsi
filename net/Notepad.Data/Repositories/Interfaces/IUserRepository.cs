using Microsoft.AspNetCore.Identity;

namespace Notepad.Data.Repositories.Interfaces;

public interface IUserRepository
{
    public IdentityUser GetUserByUsername(string username);
}