using Curate.Domain.Entities.Auth;

namespace Curate.Application.Interface.Auth;

public interface IAuthRepository
{
    Task<bool> Create(User otp);
    Task<User?> GetById(int userId);
    Task<User?> GetByEmail(string email);
    Task Update(User user);
}