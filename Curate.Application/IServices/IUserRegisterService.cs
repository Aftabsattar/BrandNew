using Curate.Domain.Entities.Auth;

namespace Curate.Application.IServices;

public interface IUserRegisterService
{
    Task<UserRegister> Create(string email);
    //Task<string> Update(UserRegister  user);
    Task<UserRegister> GetByEmail(string email);
    Task<UserRegister> GetById(int id);
}