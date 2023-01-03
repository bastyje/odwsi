using Notepad.Data.Entities;
using Notepad.Data.Repositories.Interfaces;
using Notepad.Service.Models;
using Notepad.Service.Services.Interfaces;

namespace Notepad.Service.Services;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;

    public NoteService(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }
    
    public ServiceMessage<List<Note>> GetPublic()
    {
        return new ServiceMessage<List<Note>>
        {
            Content = _noteRepository.GetPublic()
        };
    }

    public ServiceMessage<List<Note>> GetMy(string userId)
    {
        return new ServiceMessage<List<Note>>
        {
            Content = _noteRepository.GetMy(userId)
        };
    }

    public ServiceMessage<List<Note>> GetShared(string userId)
    {
        return new ServiceMessage<List<Note>>
        {
            Content = _noteRepository.GetShared(userId)
        };
    }

    public ServiceMessage<Note> GetById(string id)
    {
        return new ServiceMessage<Note>
        {
            Content = _noteRepository.GetById(id)
        };
    }

    public ServiceMessage Create(Note note, string userId)
    {
        var serviceMessage = new ServiceMessage();
        note.Id = Guid.NewGuid().ToString();
        note.UserId = userId;
        _noteRepository.Add(note);
        return serviceMessage;
    }
}