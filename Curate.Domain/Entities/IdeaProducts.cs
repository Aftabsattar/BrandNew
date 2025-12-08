namespace Curate.Domain.Entities;

public class IdeaProducts
{
    public int IdeaId { get; set; }
    public Idea Idea { get; set; } 
    public int ProductId { get; set; }
    public Product Product { get; set; }
}