using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Notepad.Data.Entities;

namespace Notepad.Data.Configuration;

public static class SecurityConfiguration
{
    public static void ConfigureSecurity(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationUser>().ToTable("User", Schema.Security);
        modelBuilder.Entity<BlacklistPassword>().ToTable("BlacklistPassword", Schema.Security);
    }
}