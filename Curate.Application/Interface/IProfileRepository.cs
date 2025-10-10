using Curate.Domain.Entities.Auth;

namespace Curate.Application.Interface;

public interface IProfileRepository
{
    Task<bool> Create(User profile);
    Task<bool> Update(User createDto);
    Task<bool> Delete(int id);
    Task<List<User>> GetAll();
    Task<User> GetById(int id);
}