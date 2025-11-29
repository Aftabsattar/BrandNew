using System.Security.Cryptography;
using Curate.Application.Interface.Auth;
using Curate.Application.IServices;
using Curate.Domain.Entities.Auth;

namespace Curate.Infrastructre.Services;

public class OtpService : IOtpService
{
    private readonly IOtpRepository _otpRepository;
    private readonly IEmailService _emailService;
    private readonly IUserRegisterService _userRegisterService;
    private readonly IJwtService _jwtService;
    public OtpService(IOtpRepository otpRepository, IEmailService emailService, IUserRegisterService userRegisterService, IJwtService jwtService)
    {
        _otpRepository = otpRepository;
        _emailService = emailService;
        _userRegisterService = userRegisterService;
        _jwtService = jwtService;
    }

    public int GenerateOtp() 
    {
        var otpbyte = RandomNumberGenerator.GetBytes(4);
        var otp = BitConverter.ToInt32(otpbyte,0) % 10000;
        return otp;
    }

    public async Task<string> OtpGenerationWithEmail(string email)
    {
        if (email == null) throw new Exception("Please Enter a Email");
        var user = new User
        {
            Email = email,
            Otp = GenerateOtp(),
            ExpireyTime = DateTime.UtcNow.AddMinutes(5),
            IsUsed = false
        };
        var result = await _otpRepository.Create(user);
        if (result) await _emailService.SendEmailWithOtp(user.Email,user.Otp);
        return $"Email send to {user.Email}";
    }

    public async Task<string> Verify(string email, int otp)
    {
        var findOtp = await _otpRepository.GetByEmail(email);
        if (findOtp == null) return "Otp Not Found";
        if (DateTime.UtcNow > findOtp.ExpireyTime && findOtp.IsUsed) return "OTP Expired OR this allready used ";
        findOtp.IsUsed = true;
        await _otpRepository.Update(findOtp);
        var user = await _userRegisterService.GetByEmail(email);
        if (user != null) return _jwtService.GenerateJwtToken(user);
        var NewUser = await _userRegisterService.Create(email);
        return _jwtService.GenerateJwtToken(NewUser);
    }
}