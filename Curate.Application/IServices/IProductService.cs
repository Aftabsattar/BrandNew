using Curate.Application.DTO.Product;
using Curate.Domain.Entities;
using Curate.Domain.Search;

namespace Curate.Application.IServices;

public interface IProductService
{
    Task<string> Create(RequestDTo requestDTo, int userId);
    Task<string> Update(int id ,UpdateRequest updateRequest, int userId);
    Task<string> Delete(int id, int userId);
    Task<Product> GetById(int id);
    Task<PagedResult<Product>> GetAll(string? textQuery, string? sortOrder, string? sortBy, int PageNumber, int PageSize);
}
