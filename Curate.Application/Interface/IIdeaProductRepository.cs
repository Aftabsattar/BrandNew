using Curate.Domain.Entities;

namespace Curate.Application.Interface;

public interface IIdeaProductRepository
{
    Task<bool> Create(IdeaProducts idea);
    bool Delete();
    bool Update();
    bool GetAll();
    bool GetById();
}