namespace Notepad.Data.Entities;

public class ApplicationUser
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
}