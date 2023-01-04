using Notepad.Data.Entities;
using Notepad.Data.Enums;
using Notepad.Data.Repositories.Interfaces;
using Notepad.Service.Models;
using Notepad.Service.Services.Interfaces;

namespace Notepad.Service.Services;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;
    private readonly IUserRepository _userRepository;

    public NoteService(INoteRepository noteRepository, IUserRepository userRepository)
    {
        _noteRepository = noteRepository;
        _userRepository = userRepository;
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

    public ServiceMessage Create(NoteCreateModel noteCreateModel)
    {
        var serviceMessage = new ServiceMessage();
        var note = new Note
        {
            Id = Guid.NewGuid().ToString(),
            Text = noteCreateModel.Text,
            Title = noteCreateModel.Title,
            ScopeType = noteCreateModel.ScopeType,
            UserId = noteCreateModel.UserId,
            Encrypted = noteCreateModel.Encrypted,
            CreationDate = DateTime.Now
        };
        _noteRepository.Add(note);

        if (noteCreateModel.ScopeType == ScopeTypeEnum.Shared)
        {
            noteCreateModel.UserIds.ForEach(userId =>
            {
                if (_userRepository.GetById(userId) != null)
                {
                    _noteRepository.AddUserNote(new UserNote
                    {
                        NoteId = note.Id,
                        UserId = userId
                    });
                }
            });
        }

        if (_noteRepository.SaveChanges() != noteCreateModel.UserIds.Count + 1)
        {
            serviceMessage.Errors.Add(new ErrorMessage
            {
                Message = "Usable to save note"
            });
        }
        
        return serviceMessage;
    }
}