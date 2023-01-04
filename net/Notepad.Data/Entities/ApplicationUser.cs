namespace Notepad.Data.Entities;

public class ApplicationUser
{
    public string Id { get; set; }
    public string PasswordHash { get; set; }
    public DateTime LockoutEnd { get; set; }
    public int FailedAttempts { get; set; }
}