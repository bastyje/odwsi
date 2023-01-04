using System.Security.Claims;
using System.Security.Cryptography;
using Notepad.Data.Entities;
using Notepad.Data.Repositories.Interfaces;
using Notepad.Service.Models;
using Notepad.Service.Services.Interfaces;

namespace Notepad.Service.Services;

public class UserService : IUserService
{
    private const int LOCKOUT_DURATION = 5;
    private const int MAX_FAILED_ATTEMPTS = 3;
    private const int ITERATIONS = 100000;
    private const int HASH_LENGTH = 20;
    private const int SALT_LENGTH = 16;
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public ApplicationUser GetUser(string username)
    {
        return _userRepository.GetById(username);
    }

    public ServiceMessage Register(RegisterUserModel registerUserModel)
    {
        var serviceMessage = new ServiceMessage();
        var user = _userRepository.GetById(registerUserModel.UserName);
        if (user == null)
        {
            if (!_userRepository.IsPasswordBlacklist(registerUserModel.Password))
            {
                _userRepository.Add(new ApplicationUser
                {
                    Id = registerUserModel.UserName,
                    PasswordHash = HashPassword(registerUserModel.Password),
                    FailedAttempts = 0,
                    LockoutEnd = DateTime.MinValue
                });
            }
            else
            {
                serviceMessage.Errors.Add(new ErrorMessage
                {
                    Message = "This password is common and it is not safe to use it."
                });
            }
        }
        else
        {
            serviceMessage.Errors.Add(new ErrorMessage
            {
                Message = $"User with username {registerUserModel.UserName} already exists"
            });
        }

        return serviceMessage;
    }

    private static string HashPassword(string password)
    {
        var salt = new byte[SALT_LENGTH];
        new RNGCryptoServiceProvider().GetBytes(salt);
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, ITERATIONS);
        var hash = pbkdf2.GetBytes(HASH_LENGTH);
        var hashBytes = new byte[SALT_LENGTH + HASH_LENGTH];
        Array.Copy(salt, 0, hashBytes, 0, SALT_LENGTH);
        Array.Copy(hash, 0, hashBytes, SALT_LENGTH,  HASH_LENGTH);
        return Convert.ToBase64String(hashBytes);
    }

    public bool VerifyPassword(string dbPassword, string enteredPassword)
    {
        var hashBytes = Convert.FromBase64String(dbPassword);
        var salt = new byte[SALT_LENGTH];
        Array.Copy(hashBytes, 0, salt, 0, SALT_LENGTH);
        var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, ITERATIONS);
        var hash = pbkdf2.GetBytes(HASH_LENGTH);

        var verified = true;
        for (var i = 0; i < HASH_LENGTH; i++)
            if (hashBytes[i + SALT_LENGTH] != hash[i])
                verified = false;
        
        return verified;
    }

    public void ReportFailedLogin(string userId)
    {
        var user = _userRepository.GetById(userId);
        user.FailedAttempts++;
        
        if (user.FailedAttempts >= MAX_FAILED_ATTEMPTS)
        {
            user.FailedAttempts = 0;
            user.LockoutEnd = DateTime.Now.Add(new TimeSpan(0, LOCKOUT_DURATION, 0));
            _userRepository.Update(user);
        }
        else
        {
            _userRepository.Update(user);
        }
    }
}