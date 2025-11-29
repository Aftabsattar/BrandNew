using Curate.Application.DTO.Auth;
using Curate.Domain.Entities.Auth;

namespace Curate.Application.IServices;

public interface IRegisterService
{
    Task<string> Create(UserRegisterDto registerDto); 
    Task<string> Delete(int id);
    Task<List<User>> GetAll();
    Task<User> GetById(int id);
    Task<string> Update(int id, UpdateUserDto registerDto);
}