using Notepad.Data.Entities;
using Notepad.Service.Models;

namespace Notepad.Service.Services.Interfaces;

public interface INoteService
{
    ServiceMessage<List<Note>> GetPublic();
    ServiceMessage<List<Note>> GetMy(string userId);
    ServiceMessage<List<Note>> GetShared(string userId);
    ServiceMessage<Note> GetById(string id);
    ServiceMessage Create(Note note, string userId);
}