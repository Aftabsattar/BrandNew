using Curate.Application.DTO.Idea;
using Curate.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Curate.API.Controllers
{
    [Route("api/idea")]
    [ApiController]
    public class IdeaController : ControllerBase
    {
        private readonly IIdeaService _ideaService;
        public IdeaController(IIdeaService ideaService)
        {
            _ideaService = ideaService;
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

        [HttpPost("create")]
        public async Task<IActionResult> Create(IdeaRequestDto requestDto)
        {
            var result = await _ideaService.Create(requestDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, IdeaUpdateDto updatetDto)
        {
            var result = await _ideaService.Update(id, updatetDto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _ideaService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var resutl = await _ideaService.GetById(id);
            return Ok(resutl);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ideaService.DeleteAsync(id);
            return Ok(result);
        }
    }
}