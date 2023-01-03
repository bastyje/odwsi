using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notepad.API.Services.Interfaces;
using Notepad.Data.Entities;
using Notepad.Data.Repositories.Interfaces;
using Notepad.Service.Services.Interfaces;

namespace Notepad.API.Controllers;

[Authorize]
[Route("[controller]")]
public class NoteController : ControllerBase
{
    private readonly INoteService _noteService;
    private readonly ICurrentUserService _currentUserService;

    public NoteController(INoteService noteService, ICurrentUserService currentUserService)
    {
        _noteService = noteService;
        _currentUserService = currentUserService;
    }
    
    [HttpGet]
    public ActionResult GetPublic()
    {
        return new OkObjectResult(_noteService.GetPublic());
    }
    
    [HttpPost]
    public ActionResult AddNote([FromBody] Note note)
    {
        return new OkObjectResult(_noteService.Create(note, _currentUserService.UserId));
    }

    [HttpGet("{id}")]
    public ActionResult GetById(string id)
    {
        return new OkObjectResult(_noteService.GetById(id));
    }

    [HttpGet("shared")]
    public ActionResult GetShared()
    {
        return new OkObjectResult(_noteService.GetShared(_currentUserService.UserId));
    }

    [HttpGet("my")]
    public ActionResult GetMy()
    {
        return new OkObjectResult(_noteService.GetMy(_currentUserService.UserId));
    }
}