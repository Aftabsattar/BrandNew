using Curate.Domain.Entities.Auth;

namespace Curate.Application.Interface;

public interface IUserRegisterRepository
{
    Task<UserRegister> Create(UserRegister passcodeDto);
    Task<bool> Update(UserRegister passcodeDto);
    Task<UserRegister> GetById(int id);
    Task<UserRegister> GetByEmail(string email);
}