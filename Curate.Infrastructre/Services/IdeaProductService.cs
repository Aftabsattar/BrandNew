using Curate.Application.Interface;
using Curate.Application.IServices;
using Curate.Domain.Entities;
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

    public async Task<bool> Create(Idea idea)
    {
        if (idea == null) return false;
        var IdeaProduct = new IdeaProducts
        {
            IdeaId = idea.Id,
            ProductId = idea.ProductId.First().ProductId
        };
        var result =await _ideaProductRepository.Create(IdeaProduct);
        if(result) return true;
        return false;
    }

    public Task<bool> Delete()
    {
        throw new NotImplementedException();
    }

    public Task<bool> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> GetById()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update()
    {
        throw new NotImplementedException();
    }
}