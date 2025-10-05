using Curate.Domain.Entities;

namespace Curate.Application.Interface;

public interface IIdeaRepository
{
    Task<bool> CreatAsync(Idea idea);
    Task<bool> Delete(int id);
    Task<bool> UpdateAsync(Idea idea);
    Task<Idea?> GetById(int id);
    Task<List<Idea>> GetAll();
}