using Curate.Domain.Entities;
using System.Globalization;

namespace Curate.Application.IServices;

public interface IIdeaProductServices
{
    Task<bool> Create(Idea idea);
    Task<bool> Delete();
    Task<bool> Update();
    Task<bool> GetAll();
    Task<bool> GetById();
}