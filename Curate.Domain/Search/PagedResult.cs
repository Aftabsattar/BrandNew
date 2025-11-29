using Curate.Domain.Entities;

namespace Curate.Domain.Search;

public class PagedResult<T>
{
    public int TotalRecords { get; set; }
    public  int  PageSize { get; set; }
    public int PageNumber { get; set; }
    public int TotalPage { get; set; }
    public List<Product> Items { get; set; }
}