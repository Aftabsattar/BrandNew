using Curate.Application.DTO;
using Curate.Domain.Entities.Auth;

namespace Curate.Application.Interface.Auth;

public interface IRegisterRepository
{
    Task<bool> Create(Register registerDto);
    Task<bool> Delete(int id);
    Task<List<Register>> GetAll();
    Task<Register> GetById(int id);
    Task<bool> Update(Register updateDto);
}