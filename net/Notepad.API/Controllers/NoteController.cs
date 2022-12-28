using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Notepad.API.Controllers;

[Authorize]
[Route("[controller]")]
public class NoteController : ControllerBase
{
    [HttpGet]
    public ActionResult GetAll()
    {
        return new OkObjectResult(1);
    }
}