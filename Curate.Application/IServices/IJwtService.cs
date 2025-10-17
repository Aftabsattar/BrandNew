using Curate.Domain.Entities.Auth;

namespace Curate.Application.IServices;

public interface IJwtService
{
   string GenerateJwtToken(User userRegister);
}