using System.Security.Cryptography;
using Curate.Application.DTO.Auth;
using Curate.Application.Interface.Auth;
using Curate.Application.IServices;
using Curate.Domain.Entities.Auth;

namespace Curate.Infrastructre.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly IEmailService _emailService;
    private readonly IUserRegisterService _userRegisterService;
    private readonly IJwtService _jwtService;
    public AuthService(IAuthRepository authRepository, IEmailService emailService, IUserRegisterService userRegisterService, IJwtService jwtService)
    {
        _authRepository = authRepository;
        _emailService = emailService;
        _userRegisterService = userRegisterService;
        _jwtService = jwtService;
    }

    public async Task<string> CreatePasscode(PasscodeDto user , int userId)
    {
        var result = await _authRepository.GetById(userId);
        var userpasscode = Convert.ToString(result.Passcode);
        if (result.IsUsed && result.IsVerified && string.IsNullOrEmpty(userpasscode))
        {
            result.Passcode = user.Passcode;
            await _authRepository.Update(result);
            return $"Passcode Create {result.Email} to this email";
        }
        return $"Passcode Already exist {result.Email} to this email";
    }

    public int GenerateOtp() 
    {
        var otpbyte = RandomNumberGenerator.GetBytes(4);
        var otp = BitConverter.ToInt32(otpbyte,0) % 10000;
        return otp;
    }

    public async Task<string> OtpGenerationWithEmail(RequestOtpDto requestOtpDto)
    {
        if (requestOtpDto.Email== null) throw new Exception("Please Enter a Email");
        var user = new User
        {
            Email = requestOtpDto.Email,
            Otp = GenerateOtp(),
            ExpireyTime = DateTime.UtcNow.AddMinutes(5),
            IsUsed = false
        };
        var result = await _authRepository.Create(user);
        if (result) await _emailService.SendEmailWithOtp(user.Email,user.Otp);
        return $"Email send to {user.Email}";
    }

    public async Task<string> UpdatePasscode(PasscodeDto user, int userId)
    {
        var result = await _authRepository.GetById(userId);
        var userpasscode = Convert.ToString(result.Passcode);
        if (result.IsUsed && result.IsVerified && !string.IsNullOrEmpty(userpasscode))
        {
            result.Passcode = user.Passcode;
            await _authRepository.Update(result);
        }
        else return "User not verified OR PassCode Not Set Properly";
        return $"Passcode Update {result.Email} to this email";
    }

    public async Task<string> Verify(string email, int otp)
    {
        User? user= await _authRepository.GetByEmail(email);
        if (user == null) return "Otp Not Found";
        if (DateTime.UtcNow > user.ExpireyTime && user.IsUsed is false) return "OTP Expired OR this allready used ";
        user.IsUsed = true;
        await _authRepository.Update(user);
        var FindUser = await _userRegisterService.GetById(user.Id);
        if (FindUser.IsUsed && FindUser.IsVerified is false) 
        {
            FindUser.IsVerified = true; await _authRepository.Update(user); 
        }

        
        return _jwtService.GenerateJwtToken(FindUser);
    }
}