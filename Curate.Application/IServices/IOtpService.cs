namespace Curate.Application.IServices;

public interface IOtpService
{
    Task<string> OtpGenerationWithEmail(string email);
    Task<string> Verify(string email ,int token);
}