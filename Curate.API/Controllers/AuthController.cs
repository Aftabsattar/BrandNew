using Curate.Application.DTO.Auth.Login;
using Curate.Application.DTO.Auth.SignUp;
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

        [HttpPost("Login-with-passcode")]
        public async Task<IActionResult> Login(LoginWithPasscodeDto login) 
        {
            var result = await _authService.Login(login);
            return Ok(result);
        }

        [HttpPost("Login-with-Email")]
        public async Task<IActionResult> LoginWithEmail(RequestOtpDto login) 
        {
            var result = Convert.ToInt32(await _authService.OtpGenerationWithEmail(login));
            return Ok(result);
        }
    }
}