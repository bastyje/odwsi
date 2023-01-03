using Microsoft.EntityFrameworkCore;
using Notepad.Data.Entities;

namespace Notepad.Data.Configuration;

public static class DboConfiguration
{
    public static void ConfigureDbo(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserNote>().ToTable("UserNote", Schema.Dbo).HasKey(un =>
        new { un.UserId, un.NoteId });
    }
}