using Curate.Application.DTO.Auth;
using Curate.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Curate.API.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRegisterService _userRegisterService;
        public AuthController(IUserRegisterService userRegisterService)
        {
            _userRegisterService = userRegisterService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterDto registerDto)
        {
            var result = await _userRegisterService.Register(registerDto);
            return Ok(result);
        }
    }
}
