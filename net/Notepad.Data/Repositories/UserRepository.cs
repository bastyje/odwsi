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

    public ApplicationUser GetById(string id)
    {
        return _dbContext.User.FirstOrDefault(u => u.Id == id);
    }

    public void Add(ApplicationUser applicationUser)
    {
        _dbContext.Add(applicationUser);
        _dbContext.SaveChanges();
    }

    public void Update(ApplicationUser applicationUser)
    {
        _dbContext.Update(applicationUser);
        _dbContext.SaveChanges();
    }

    public bool IsPasswordBlacklist(string password)
    {
        return _dbContext.BlacklistPasswords.Any(bp => bp.Password == password);
    }
}