using Curate.Domain.Entities.Auth;

namespace Curate.Application.Interface.Auth;

public interface IAuthRepository
{
    Task<bool> Create(User otp);
    Task<User?> GetByEmail(string email);
    Task Update(User user);
}