using Curate.Application.DTO.Idea;
using Curate.Application.Interface;
using Curate.Application.IServices;
using Curate.Domain.Entities;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Crypto;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Curate.Infrastructre.Services;

public class IdeaProductService : IIdeaProductServices
{
    private readonly IIdeaProductRepository _ideaProductRepository;
    public IdeaProductService(IIdeaProductRepository ideaProductRepository)
    {
        _ideaProductRepository = ideaProductRepository;
    }

    public async Task<bool> Create(IdeaProducts idea)
    {
        if (idea == null) return false;
        await _ideaProductRepository.Create(idea);
        return true;
    }

    public async Task<List<IdeaDto>> GetAll(int userId)
    {
        return await _ideaProductRepository.GetAll(userId);
    }

    public async Task<IdeaDto?> GetById(int id, int userId)
    {
        return await _ideaProductRepository.GetById(id, userId);
    }

    public async Task<bool> Update(IdeaProducts ideaProduct)
    {
        var result = await _ideaProductRepository.Update(ideaProduct);
        return result;
    }
}