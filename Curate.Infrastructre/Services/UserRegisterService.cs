using Curate.Application.DTO.Auth.SignUp;
using Curate.Application.Interface;
using Curate.Application.IServices;
using Curate.Domain.Entities.Auth;

namespace Curate.Infrastructre.Services;

public class UserRegisterService : IUserRegisterService
{
    private readonly IUserRegisterRepository _userRegisterRepo;
    public UserRegisterService(IUserRegisterRepository userRegisterRepo)
    {
        _userRegisterRepo = userRegisterRepo;
    }

    public async Task<User> Create(string email)
    {
        var user = new User
        {
            Email = email,
        };
        var result = await _userRegisterRepo.Create(user);
        return result;
    }

    public async Task<User> GetByEmail(string email)
    {
        return await _userRegisterRepo.GetByEmail(email);
    }

    public async Task<User> GetById(int id)
    {
        return await _userRegisterRepo.GetById(id);
    }

    public async Task<string> Update(UpdateUserDto user)
    {
        var FindUser = await _userRegisterRepo.GetByEmail(user.Email);
        if (FindUser != null && user != null)
        {
            FindUser.Email = user.Email;
            FindUser.Passcode = user.Passcode;
            FindUser.PasscodeCreatedAt = user.PasscodeCreatedAt;
            var result = await _userRegisterRepo.Update(FindUser);
            if (result) return "User update successfulley";
        }
        return "User Not Update successfulley";
    }
}