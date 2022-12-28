using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Notepad.Data.Configuration;

namespace Notepad.Data.Entities;

public static class IdentityUserConfiguration
{
    public static void ConfigureSecurity(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUser>().ToTable("IdentityUser", Schema.Security);
        modelBuilder.Entity<IdentityUserLogin<string>>()
            .ToTable("IdentityUserLogin", Schema.Security)
            .HasKey(l => new {l.LoginProvider, l.ProviderKey});
        modelBuilder.Entity<IdentityUserRole<string>>()
            .ToTable("IdentityUserRole", Schema.Security)
            .HasKey(r => new { r.RoleId, r.UserId });
        modelBuilder.Entity<IdentityUserToken<string>>()
            .ToTable("IdentityUserToken")
            .HasKey(t => new { t.LoginProvider, t.UserId });
        // modelBuilder
    }
}