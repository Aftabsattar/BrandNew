using Curate.Domain.Entities.Auth;

namespace Curate.Application.Interface;

public interface IUserRegisterRepository
{
    Task<bool> Create(UserRegister passcodeDto);
    Task<bool> Update(UserRegister passcodeDto);
    Task<UserRegister> GetByEmail(string email);
}