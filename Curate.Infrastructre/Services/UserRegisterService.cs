using Curate.Application.DTO.Auth;
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

    public async Task<UserRegister> Create(string email)
    {
        var user = new UserRegister
        {
            Email = email,
        };
        var result = await _userRegisterRepo.Create(user);
        return result;
    }

    public async Task<UserRegister> GetByEmail(string email)
    {
        return await _userRegisterRepo.GetByEmail(email);
    }

    public async Task<UserRegister> GetById(int id)
    {
        return await _userRegisterRepo.GetById(id);
    }

    public async Task<string> Update(PasscodeDto user)
    {
        var FindUser = await _userRegisterRepo.GetByEmail(user.Email);
        if (FindUser != null && user != null)
        {
            var result = await _userRegisterRepo.Update(FindUser);
            if (result) return "User passcode successfulley";
        }
        return "User passcode Not Update successfulley";
    }
}