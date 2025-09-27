namespace BrandNew.Domain.Entities;

public class Idea
{
    public  int  Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateOnly CreateAt { get; set; } 
    public string ImageUrl { get; set; } = string.Empty;
}