using Curate.Application.DTO.Idea;
using Curate.Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Curate.API.Controllers
{
    [Route("api/idea")]
    [ApiController]
    public class IdeaController : ControllerBase
    {
        private readonly IIdeaService _ideaService;
        private readonly IIdeaProductServices _ideaProductServices;
        public IdeaController(IIdeaService ideaService, IIdeaProductServices ideaProductServices)
        {
            _ideaService = ideaService;
            _ideaProductServices = ideaProductServices;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile formFile)
        {
            var FileName = Path.GetFileName(formFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\image", FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(fileStream);
            }
            var baseurl = $"{Request.Scheme}://{Request.Host}";
            var PublicUrl = $"{baseurl}/Image/{FileName}";
            return Ok(PublicUrl);
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> Create(IdeaRequestDto requestDto)
        {
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _ideaService.Create(requestDto,userId);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, IdeaUpdateDto updatetDto)
        {
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _ideaService.Update(id ,updatetDto, userId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _ideaProductServices.GetAll(userId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var resutl = await _ideaProductServices.GetById(id,userId);
            return Ok(resutl);
        }

        //[Authorize]
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        //    var result = await _ideaService.DeleteAsync(id,userId);
        //    return Ok(result);
        //}
    }
}