using Curate.Application.DTO.Search;
using Curate.Domain.Entities;
using Curate.Domain.Search;

namespace Curate.Application.Interface;

public interface IProductRepository
{
    Task<bool> Create(Product product);
    Task<IQueryable<Product>> GetAll(string? textQuery, string? sortOrder, string? sortBy);
    Task<Product> GetById(int id);
    Task<List<int>> GetAllId();
    Task<bool> Update(Product product);
    Task<bool> Delete(int id);
}