using Curate.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Curate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IOtpService _otpService;
        public AuthController(IOtpService userRegisterService)
        {
            _otpService  = userRegisterService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOtp(string email)
        {
            var result =await _otpService.TokenGenerationWithEmail(email);
            return Ok(result);
        }

        [HttpPost("token")] 
        public async Task<IActionResult> VerificationOtp(string email,int token)
        {
           var result = await _otpService.Verify(email,token);
            return Ok(result);
        }
    }
}