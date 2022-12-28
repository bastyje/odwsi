using Microsoft.AspNetCore.Identity;
using Notepad.Data.DbContexts;
using Notepad.Data.Repositories.Interfaces;

namespace Notepad.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SecurityDbContext _dbContext;

    public UserRepository(SecurityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IdentityUser GetUserByUsername(string username)
    {
        return _dbContext.IdentityUsers.FirstOrDefault(u => u.UserName == username);
    }
}