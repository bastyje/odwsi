using Notepad.Data.Entities;

namespace Notepad.Data.Repositories.Interfaces;

public interface IUserRepository
{
    public ApplicationUser GetByUsername(string username);
    public void Add(ApplicationUser applicationUser);
    public bool IsPasswordBlacklist(string password);
}