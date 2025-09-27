using BrandNew.Application.DTO;

namespace BrandNew.Application.IServices;

public interface IIdeaService
{
    Task<string> Create(RequestDto requestDto);
    Task<string> Update(RequestDto requestDto);
    Task<string> Delete(RequestDto requestDto);
    Task<string> GetAll(RequestDto requestDto);
    Task<string> GetById(int id);   
}