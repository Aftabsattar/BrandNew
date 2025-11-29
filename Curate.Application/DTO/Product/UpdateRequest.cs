namespace Curate.Application.DTO.Product;

public class UpdateRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; }
    public string RetailerName { get; set; } = string.Empty;
    public DateTime UpdateAt { get; set; }
}