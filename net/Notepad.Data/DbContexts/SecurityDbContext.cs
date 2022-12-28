using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Notepad.Data.Entities;

namespace Notepad.Data.DbContexts;

public class SecurityDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public SecurityDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {}

    public DbSet<IdentityUser> IdentityUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfigurationsFromAssembly(typeof(SecurityDbContext).Assembly);
        modelBuilder.ConfigureSecurity();
    }
}