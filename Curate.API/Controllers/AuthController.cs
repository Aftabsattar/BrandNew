using Curate.Application.DTO.Auth;
using Curate.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Curate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IOtpService _otpService;
        private readonly IUserRegisterService _userRegisterService;
        public AuthController(IOtpService otpService, IUserRegisterService userRegisterService)
        {
            _otpService  = otpService;
            _userRegisterService = userRegisterService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOtp(string email)
        {
            var result =await _otpService.TokenGenerationWithEmail(email);
            return Ok(result);
        }

        [HttpPost("token")]
        public async Task<IActionResult> VerificationOtp(string email, int token)
        {
            var result = await _otpService.Verify(email, token);
            return Ok(result);
        }

        [HttpPost("passcode")]
        public async Task<IActionResult> Create(PasscodeDto passcodeDto)
        {
            var result = await _userRegisterService.Create(passcodeDto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(PasscodeDto passcodeDto) 
        {
            var result = await _userRegisterService.Update(passcodeDto);
            return Ok(result);
        }
    }
}