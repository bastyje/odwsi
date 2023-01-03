using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Notepad.Data.Configuration;
using Notepad.Data.Entities;

namespace Notepad.Data.DbContexts;

public class NotepadDbContext : DbContext
{
    public NotepadDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {}

    #region Dbo

    public DbSet<Note> Note { get; set; }
    public DbSet<UserNote> UserNote { get; set; }

    #endregion
    
    #region Security
    
    public DbSet<ApplicationUser> User { get; set; }
    public DbSet<BlacklistPassword> BlacklistPasswords { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureDbo();
        modelBuilder.ConfigureSecurity();
    }
}