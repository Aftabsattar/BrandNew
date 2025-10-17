using Curate.Application.DTO.Auth.SignUp;
using Curate.Domain.Entities.Auth;

namespace Curate.Application.IServices;

public interface IUserRegisterService
{
    Task<User> Create(string email);
    Task<string> Update(UpdateUserDto  user);
    Task<User> GetByEmail(string email);
    Task<User> GetById(int id);
}