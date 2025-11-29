using Curate.Application.DTO;
using Curate.Domain.Entities.Auth;

namespace Curate.Application.Interface.Auth;

public interface IRegisterRepository
{
    Task<bool> Create(User registerDto);
    Task<bool> Delete(int id);
    Task<List<User>> GetAll();
    Task<User> GetById(int id);
    Task<bool> Update(User updateDto);
}