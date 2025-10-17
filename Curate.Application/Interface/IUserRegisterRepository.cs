using Curate.Domain.Entities.Auth;

namespace Curate.Application.Interface;

public interface IUserRegisterRepository
{
    Task<User> Create(User user);
    Task<bool> Update(User user);
    Task<User> GetById(int id);
    Task<User> GetByEmail(string email);
}