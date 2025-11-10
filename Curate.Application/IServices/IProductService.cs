using Curate.Application.DTO.Product;

namespace Curate.Application.IServices;

public interface IProductService
{
    Task<string> Create(RequestDTo requestDTo);
    Task<string> Update(RequestDTo requestDTo);
    Task<string> Delete(int id);
    Task<string> GetById(int id);
    Task<string> GetAll();
}
