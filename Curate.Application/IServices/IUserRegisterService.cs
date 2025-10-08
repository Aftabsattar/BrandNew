using Curate.Application.DTO.Auth;

namespace Curate.Application.IServices;

public interface IUserRegisterService
{
    Task<string> Register(RegisterDto registerDto); 
    Task<string> Delete();
    Task<string> GetAll();
    Task<string> GetById(int id);
    Task<string> Update(string name);
}