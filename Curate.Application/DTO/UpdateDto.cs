using Microsoft.AspNetCore.Http;

namespace Curate.Application.DTO;

public class UpdateDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public IFormFile MainImage { get; set; } 
}