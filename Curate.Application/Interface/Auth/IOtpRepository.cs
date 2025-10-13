using Curate.Domain.Entities.Auth;

namespace Curate.Application.Interface.Auth;

public interface IOtpRepository
{
    Task<bool> Create(OTP otp);
    Task<OTP?> GetByEmail(string email);
    Task Update(OTP oTP);
}