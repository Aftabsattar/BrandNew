using Curate.Application.DTO.Idea;
using Curate.Domain.Entities;

namespace Curate.Application.IServices;

public interface IIdeaService
{
    Task<string> Create(IdeaRequestDto requestDto);
    Task<string> Update(int id, IdeaUpdateDto updatetDto);
    Task<string> DeleteAsync(int id);
    Task<List<Idea>> GetAll();
    Task<Idea?> GetById(int id);
}