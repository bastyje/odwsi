using Notepad.Data.Enums;

namespace Notepad.Service.Models;

public class NoteCreateModel
{
    public string Title { get; set; }
    public string Text { get; set; }
    public List<string> UserIds { get; set; }
    public string UserId { get; set; }
    public ScopeTypeEnum ScopeType { get; set; }
    public bool Encrypted { get; set; }
}