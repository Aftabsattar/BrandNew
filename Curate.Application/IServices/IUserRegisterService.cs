using Curate.Application.DTO.Auth;

namespace Curate.Application.IServices;

public interface IUserRegisterService
{
    Task<string> Create(PasscodeDto createDto);
    Task<string> Update(PasscodeDto createDto);
    //Task<string> Delete(int id);
    //Task<List<UserRegister>> GetAll();
    //Task<UserRegister> GetById(int id);
    //Task<string> PasscodeGeneration(PasscodeDto passcodeDto);
}