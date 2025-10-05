using Curate.Application.DTO;
using Curate.Domain.Entities;

namespace Curate.Application.IServices;

public interface IIdeaService
{
    Task<string> Create(RequestDto requestDto);
    Task<string> Update(int id, UpdateDto updatetDto);
    Task<string> DeleteAsync(int id);
    Task<List<Idea>> GetAll();
    Task<Idea?> GetById(int id);
}