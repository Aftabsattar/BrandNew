using Curate.Domain.Entities;

namespace Curate.Application.Interface;

public interface IIdeaRepository
{
    Task<bool> CreatAsync(Idea idea);
    Task<bool> DeleteAsync(Idea idea);
    bool UpdateAsync(Idea idea);
    Task<Idea?> GetById(int id);
    IQueryable<Idea> GetAll();
}