
namespace Curate.Application.DTO;

public class RequestDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int? UserId { get; set; } = null;
    public DateOnly CreateAt { get; set; }
}