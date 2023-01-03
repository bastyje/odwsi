using Notepad.Data.Enums;

namespace Notepad.Data.Entities;

public class Note
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public ScopeTypeEnum ScopeType { get; set; }
    public string UserId { get; set; }
}