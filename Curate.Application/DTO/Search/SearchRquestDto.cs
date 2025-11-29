namespace Curate.Application.DTO.Search;

public class SearchRquestDto
{
    public string TextQuery { get; set; } = string.Empty;
    public string SortBy { get; set; } = string.Empty;
    public string SortOrder { get; set; } = string.Empty;
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}