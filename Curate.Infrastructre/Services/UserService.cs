using Curate.Application.DTO.Auth;
using Curate.Application.Interface.Auth;
using Curate.Application.IServices;

namespace Curate.Infrastructre.Services;

public class UserService:IUserRegisterService
{
    private readonly IRegisterRepository _userRepository;
    public UserService(IRegisterRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<string> Delete()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<string> Register(RegisterDto registerDto)
    {
        var result = _userRepository.Register(registerDto);
    }

    public Task<string> Update(string name)
    {
        throw new NotImplementedException();
    }
}