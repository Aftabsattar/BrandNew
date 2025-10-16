using Curate.Domain.Entities.Auth;

namespace Curate.Application.Interface;

public interface IProfileRepository
{
    Task<bool> Create(UserProfile profile);
    Task<bool> Update(UserProfile createDto);
    Task<bool> Delete(int id);
    Task<List<UserProfile>> GetAll();
    Task<UserProfile> GetById(int id);
}