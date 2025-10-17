using Curate.Application.DTO.Auth;
using Curate.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Curate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
       
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("create-otp")]
        public async Task<IActionResult> CreateOtp(RequestOtpDto requestOtpDto)
        {
            var result =await _authService.OtpGenerationWithEmail(requestOtpDto);
            return Ok(result);
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerificationOtp(VerifyOtpDto verifyOtpDto)
        {
            var result = await _authService.Verify(verifyOtpDto.Email,verifyOtpDto.Otp);
            return Ok(result);
        }

        [HttpPost("create-passcode")]
        public async Task<IActionResult> Create(PasscodeDto passcodeDto)
        {
            var result = await _authService.CreatePasscode(passcodeDto);
            return Ok(result);
        }

        [HttpPut("update-passcode")]
        public async Task<IActionResult> Update(PasscodeDto passcodeDto)
        {
            var result = await _authService.UpdatePasscode(passcodeDto);
            return Ok(result);
        }
    }
}