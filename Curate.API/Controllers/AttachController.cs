using Curate.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachController : ControllerBase
    {
        public AttachController()
        {
            
        }
        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile formFile, AttachFile attachFile)
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

    }
}
