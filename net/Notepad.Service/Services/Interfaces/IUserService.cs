using Notepad.Service.Models;

namespace Notepad.Service.Services.Interfaces;

public interface IUserService
{
    void Register(RegisterUserModel registerUserModel);
}