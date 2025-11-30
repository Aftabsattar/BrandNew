using Curate.Application.DTO.Product;
using Curate.Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Curate.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile formFile)
        {
            var FileName = Path.GetFileName(formFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Product", FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(fileStream);
            }
            var Baseurl = $"{Request.Scheme}://{Request.Host}";
            var PublicUrl = $"{Baseurl}/Product/{FileName}";
            return Ok(new UploadImageResponse { ImageUrl = Baseurl, SourceUrl = PublicUrl});
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(RequestDTo requestDTo)
        {
            var userId =Convert.ToInt32( User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _productService.Create(requestDTo,userId);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id , UpdateRequest requestDTo)
        {
            var userId = Convert.ToInt32( User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _productService.Update(id , requestDTo, userId);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _productService.Delete(id, userId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string? textQuery, string? sortBy = "Id", string? sortOrder = "Asce", int PageNumber =1, int PageSize = 6)
        { 
            var result = await _productService.GetAll(textQuery , sortBy, sortOrder, PageNumber, PageSize);
            return Ok(result);
        }
    }
}