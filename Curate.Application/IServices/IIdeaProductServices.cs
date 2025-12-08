using Curate.Application.DTO.Idea;
using Curate.Domain.Entities;
using System.Globalization;

namespace Curate.Application.IServices;

public interface IIdeaProductServices
{
    Task<bool> Create(IdeaProducts idea);
    Task<bool> Update(IdeaProducts ideaProducts);
    Task<List<IdeaDto>> GetAll(int userId);
    Task<IdeaDto?> GetById(int id ,int userId);
}