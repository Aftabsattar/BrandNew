using Curate.Application.DTO.Idea;
using Curate.Domain.Entities;

namespace Curate.Application.Interface;

public interface IIdeaProductRepository
{
    Task<bool> Create(IdeaProducts idea);
    Task<bool> Update(IdeaProducts ideaProducts);
    Task<List<IdeaDto>> GetAll(int userId);
    Task<IdeaDto?> GetById(int id, int userId);
}