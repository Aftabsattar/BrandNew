namespace Curate.Domain.Entities;

public class IdeaProducts
{
    public int id { get; set; }
    public int IdeaId { get; set; }
    public Idea ideaId { get; set; } = null!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}