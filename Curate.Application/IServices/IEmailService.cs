namespace Curate.Application.IServices;

public interface IEmailService
{
    Task SendEmailWithOtp(string toEmail,int otp);
}