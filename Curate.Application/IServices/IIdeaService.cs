using Curate.Application.DTO.Idea;
using Curate.Domain.Entities;

namespace Curate.Application.IServices;

public interface IIdeaService
{
    Task<string> Create(IdeaRequestDto requestDto,int userId);
    Task<string> Update(int id, IdeaUpdateDto updatetDto ,int userId);
    //Task<string> DeleteAsync(int id, int userId);
    Task<Idea?> GetById(int id, int userId);
}