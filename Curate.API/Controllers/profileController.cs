using Curate.Application.DTO.Profile;
using Curate.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Curate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class profileController : ControllerBase
    {
        private readonly IUserProfileService _profileService;
        public profileController(IUserProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile formFile)
        {
            var FileName = Path.GetFileName(formFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\profile", FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(fileStream);
            }

            var baseurl = $"{Request.Scheme}://{Request.Host}";
            var PublicUrl = $"{baseurl}/Image/{FileName}";
            return Ok(PublicUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProfileDto profile)
        {
            var result = await _profileService.Create(profile);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id , ProfileDto profileDto) 
        {
            var result = await _profileService.Update(id , profileDto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _profileService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _profileService.GetById(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _profileService.Delete(id);
            return Ok(result);
        }
    }
}