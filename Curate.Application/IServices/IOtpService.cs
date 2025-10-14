namespace Curate.Application.IServices;

public interface IOtpService
{
    Task<string> TokenGenerationWithEmail(string email);
    Task<string> Verify(string email ,int token);
}