using System.Security.Cryptography;
using Curate.Application.Interface.Auth;
using Curate.Application.IServices;
using Curate.Domain.Entities.Auth;

namespace Curate.Infrastructre.Services;

public class OtpService : IOtpService
{
    private readonly IOtpRepository _otpRepository;
    private readonly IEmailService _emailService;
    public OtpService(IOtpRepository otpRepository, IEmailService emailService)
    {
        _otpRepository = otpRepository;
        _emailService = emailService;
    }

    public int GenerateOtp() 
    {
        var otpbyte = RandomNumberGenerator.GetBytes(4);
        var otp =Convert.ToInt32(BitConverter.ToUInt32(otpbyte,0)%1000000);
        return otp;
    }

    public string GeneratePasscode()
    {
        var otpbyte = RandomNumberGenerator.GetBytes(4);
        var otp = BitConverter.ToUInt32(otpbyte, 0) % 10000;
        return otp.ToString();
    }

    public async Task<string> TokenGenerationWithEmail(string email)
    {
        if (email == null) throw new Exception("Please Enter a Email");
        var user = new OTP
        {
            Email = email,
            Otp = GenerateOtp(),
            ExpireyTime = DateTime.UtcNow.AddMinutes(5),
            IsUsed = false
        };
        var result = await _otpRepository.Create(user);
        if (result) await _emailService.SendEmailWithOtp(user.Email,user.Otp);
        return $"Email send to{user.Email}";
    }

    public async Task<string> Verify(string email, int token)
    {
        var findOtp = await _otpRepository.GetByEmail(email);
        if (findOtp == null) return "Otp Not Found";
        if (DateTime.UtcNow > findOtp.ExpireyTime) return "OTP Expired";
        if (findOtp.IsUsed) return "this OTp allready used";
        if (findOtp.Otp == token)
        {
            findOtp.IsUsed = true;
            await _otpRepository.Update(findOtp);
        }
        return "OTP verify successfuly";
    }
}