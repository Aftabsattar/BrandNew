using Curate.Application.DTO.Auth;
using Curate.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Curate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRegisterService _userRegisterService;
        public AuthController(IRegisterService userRegisterService)
        {
            _userRegisterService = userRegisterService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRegisterDto registerDto)
        {
            var result = await _userRegisterService.Create(registerDto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userRegisterService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userRegisterService.GetById(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,UserUpdateDto registerDto)
        {
            var result = await _userRegisterService.Update(id, registerDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userRegisterService.Delete(id);
            return Ok(result);
        }
    }
}