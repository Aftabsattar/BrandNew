using Curate.Domain.Entities;

namespace Curate.Application.Interface;

public interface IProductRepository
{
    Task<string> Create(Product product);
    Task<string> GetAll();
    Task<string> GetById(int id);
    Task<string> Update(Product product);
    Task<string> Delete(string product);
}