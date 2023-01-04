using Notepad.Data.Entities;

namespace Notepad.Data.Repositories.Interfaces;

public interface IUserRepository
{
    public ApplicationUser GetById(string username);
    public void Add(ApplicationUser applicationUser);
    public void Update(ApplicationUser applicationUser);
    public bool IsPasswordBlacklist(string password);
}