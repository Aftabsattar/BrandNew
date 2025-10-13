using Curate.Application.IServices;
using Curate.Domain.Entities.EmailSetting;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;

namespace Curate.Infrastructre.Services;

public class EmailService : IEmailService
{
    private readonly Email _mailsetting;
    public EmailService(IOptions<Email> mailsetting)
    {
        _mailsetting = mailsetting.Value;
    }

    public async Task SendEmailWithOtp(string toEmail, int otp)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_mailsetting.From));
        email.To.Add(MailboxAddress.Parse(toEmail));
        email.Subject = "Your OTP Code";

        email.Body = new TextPart("Plain") 
        {
            Text = $"Your OTp is {otp}.it will expire in 5 minutes."
        };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_mailsetting.SmtpServer,_mailsetting.Port,_mailsetting.UseSSL);
        await smtp.AuthenticateAsync(_mailsetting.From,_mailsetting.Password);
        smtp.Send(email);
        await smtp.DisconnectAsync(true);
    }
}