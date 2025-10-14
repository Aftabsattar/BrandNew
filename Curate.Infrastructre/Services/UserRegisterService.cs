using AutoMapper;
using Curate.Application.DTO.Auth;
using Curate.Application.Interface;
using Curate.Application.IServices;
using Curate.Domain.Entities.Auth;

namespace Curate.Infrastructre.Services;

public class UserRegisterService : IUserRegisterService
{
    private readonly IUserRegisterRepository _userRegisterRepo;
    private readonly IMapper _mapper;
    public UserRegisterService(IUserRegisterRepository userRegisterRepo, IMapper mapper)
    {
        _userRegisterRepo = userRegisterRepo;
        _mapper = mapper;
    }

    public async Task<string> Create(PasscodeDto passcodeDto)
    {
        if (passcodeDto == null) throw new Exception("please Enter a passcode");
        var passcode = new UserRegister
        {
            Email = passcodeDto.Email,
            Passcode = passcodeDto.Passcode,
        };
        var result = await _userRegisterRepo.Create(passcode);
        if (result) return "Passcode create successfulley";
        return "passcode already exist";
    }

    public async Task<string> Update(PasscodeDto user)
    {
        var FindUser = await _userRegisterRepo.GetByEmail(user.Email);
        if (FindUser != null && user != null)
        {
            FindUser.Passcode = user.Passcode;
            var result = await _userRegisterRepo.Update(FindUser);
            if (result) return "User passcode successfulley";
        }
        return "User passcode Not Update successfulley";
    }
}