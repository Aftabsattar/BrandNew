using Curate.Application.DTO.Profile;
using Curate.Domain.Entities.Auth;

namespace Curate.Application.IServices;

public interface IUserProfileService
{
    Task<string> Create(ProfileDto createDto);
    Task<string> Update(int id ,ProfileDto createDto);
    Task<string> Delete(int id);
    Task<List<UserProfile>> GetAll();
    Task<UserProfile> GetById(int id);
}