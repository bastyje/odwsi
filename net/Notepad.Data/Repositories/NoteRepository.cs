using Notepad.Data.DbContexts;
using Notepad.Data.Entities;
using Notepad.Data.Enums;
using Notepad.Data.Repositories.Interfaces;

namespace Notepad.Data.Repositories;

public class NoteRepository : INoteRepository
{
    private readonly NotepadDbContext _notepadDbContext;

    public NoteRepository(NotepadDbContext notepadDbContext)
    {
        _notepadDbContext = notepadDbContext;
    }

    public List<Note> GetPublic()
    {
        return _notepadDbContext.Note.Where(n => n.ScopeType == ScopeTypeEnum.Public).ToList();
    }

    public List<Note> GetMy(string userId)
    {
        return _notepadDbContext.Note.Where(n => n.UserId == userId).ToList();
    }

    public List<Note> GetShared(string userId)
    {
        var userNotes = _notepadDbContext.UserNote.Where(un => un.UserId == userId);
        return _notepadDbContext.Note.Where(n => userNotes.Any(un => un.NoteId == n.Id) && n.ScopeType == ScopeTypeEnum.Shared).ToList();
    }

    public Note GetById(string id)
    {
        return _notepadDbContext.Note.FirstOrDefault(n => n.Id == id);
    }

    public void Add(Note note)
    {
        _notepadDbContext.Add(note);
        _notepadDbContext.SaveChanges();
    }
}