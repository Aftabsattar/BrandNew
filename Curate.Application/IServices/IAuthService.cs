using Curate.Application.DTO.Auth;

namespace Curate.Application.IServices;

public interface IAuthService
{
    Task<string> OtpGenerationWithEmail(RequestOtpDto requestOtpDto);
    Task<string> Verify(string email ,int token);
    Task<string> CreatePasscode(PasscodeDto passcodeDto);
    Task<string> UpdatePasscode(PasscodeDto passcodeDto);
}