using Notepad.Data.Entities;

namespace Notepad.Data.Repositories.Interfaces;

public interface INoteRepository
{
    List<Note> GetPublic();
    List<Note> GetMy(string userId);
    List<Note> GetShared(string userId);
    Note GetById(string id);
    void Add(Note note);
    void AddUserNote(UserNote userNote);
    int SaveChanges();
}