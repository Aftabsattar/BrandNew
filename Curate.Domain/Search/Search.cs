namespace Curate.Domain.Search;

public class Search
{
    public int Id { get; set; }
    public string TextQuery { get; set; } = string.Empty;
    public string SortBy { get; set; } = string.Empty;
    public string SortOrder { get; set; } = string.Empty;
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}