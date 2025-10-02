using Microsoft.AspNetCore.Http;

namespace Curate.Application.DTO;

public class RequestDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public IFormFile UploadImage { get; set; }  
}