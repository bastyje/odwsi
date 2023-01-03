using Microsoft.AspNetCore.Identity;
using Notepad.Data.DbContexts;
using Notepad.Data.Entities;
using Notepad.Data.Repositories.Interfaces;

namespace Notepad.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly NotepadDbContext _dbContext;

    public UserRepository(NotepadDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ApplicationUser GetByUsername(string username)
    {
        return _dbContext.User.FirstOrDefault(u => u.UserName == username);
    }

    public void Add(ApplicationUser applicationUser)
    {
        _dbContext.Add(applicationUser);
        _dbContext.SaveChanges();
    }

    public bool IsPasswordBlacklist(string password)
    {
        return _dbContext.BlacklistPasswords.Any(bp => bp.Password == password);
    }
}