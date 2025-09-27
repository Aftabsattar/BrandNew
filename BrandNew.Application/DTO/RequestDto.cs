using Microsoft.AspNetCore.Http;

namespace BrandNew.Application.DTO;

public class RequestDto
{
    public string Title { get; set; } = string.Empty;
    public string Discription { get; set; } = string.Empty;
    public IFormFile UploadImage { get; set; }  
}