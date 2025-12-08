using Curate.Application.DTO.Product;

namespace Curate.Application.DTO.Idea;

public class IdeaDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int OwnerId { get; set; }
    public DateOnly CreateAt { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public List<ProductDto> Products { get; set; } 
}