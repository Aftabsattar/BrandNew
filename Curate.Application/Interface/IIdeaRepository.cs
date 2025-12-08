using Curate.Application.DTO.Idea;
using Curate.Domain.Entities;

namespace Curate.Application.Interface;

public interface IIdeaRepository
{
    Task<bool> CreatAsync(Idea idea);
    Task<bool> Delete(Idea idea);
    Task<bool> UpdateAsync(Idea idea);
    Task<Idea?> GetById(int id, int userId);
}