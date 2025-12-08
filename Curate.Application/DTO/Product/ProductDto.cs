namespace Curate.Application.DTO.Product;

public class ProductDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; }
    public string RetailerName { get; set; } = string.Empty;
    public List<ProductDto> Products { get; set; }
}