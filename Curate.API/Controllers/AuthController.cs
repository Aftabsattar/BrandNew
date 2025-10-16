using Curate.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Curate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IOtpService _otpService;
       
        public AuthController(IOtpService otpService)
        {
            _otpService  = otpService;
        }

        [HttpPost("create-otp")]
        public async Task<IActionResult> CreateOtp(string email)
        {
            var result =await _otpService.OtpGenerationWithEmail(email);
            return Ok(result);
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerificationOtp(string email, int token)
        {
            var result = await _otpService.Verify(email, token);
            return Ok(result);
        }

        //[HttpPost("create-passcode")]
        //public async Task<IActionResult> Create(PasscodeDto passcodeDto)
        //{
        //    var result = await _userRegisterService.Create(passcodeDto);
        //    return Ok(result);
        //}

        //[HttpPut]
        //public async Task<IActionResult> Update(PasscodeDto passcodeDto) 
        //{
        //    var result = await _userRegisterService.Update(passcodeDto);
        //    return Ok(result);
        //}


    }
}