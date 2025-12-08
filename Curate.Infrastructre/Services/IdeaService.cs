using AutoMapper;
using Curate.Application.DTO.Idea;
using Curate.Application.DTO.Product;
using Curate.Application.Interface;
using Curate.Application.IServices;
using Curate.Domain.Entities;
using Curate.Infrastructre.Context;

namespace Curate.Infrastructre.Services;

public class IdeaService : IIdeaService
{
    private readonly IIdeaRepository _idea;
    private readonly IMapper _mapper;
    private readonly IIdeaProductServices _ideaProductService;
    private readonly AppDbContext _appDbContext;
    public IdeaService(IIdeaProductServices ideaProductService,IIdeaRepository idea, IMapper mapper,AppDbContext appDbContext)
    {
        _idea = idea;
        _mapper = mapper;
        _ideaProductService = ideaProductService;
        _appDbContext = appDbContext;
    }

    public async Task<string> Create(IdeaRequestDto requestDto, int userId)
    {
        var idea = new Idea
        {
            Title = requestDto.Title,
            Description = requestDto.Description,
            ImageUrl = requestDto.ImageUrl,
            CreateAt = DateOnly.FromDateTime(DateTime.Now),
            OwnerId = userId
        };
        await _idea.CreatAsync(idea);

        if (requestDto.ProductId != null && requestDto.ProductId.Count > 0)
        {
            foreach (var productId in requestDto.ProductId)
            {
                var ideaProduct = new IdeaProducts
                {
                    IdeaId = idea.Id,
                    ProductId = productId
                };
                await _ideaProductService.Create(ideaProduct);
            }
        }
        return "Idea created succefulley";
    }


    public async Task<string> DeleteAsync(int id, int currentUserId)
    {
        var Idea = await _idea.GetById(id, currentUserId);
        if (Idea == null) return "Idea not Found";
        if (Idea.OwnerId != currentUserId && Idea.Id != id) return "You are not authorized to delete this idea";
        var deleteResult = await _idea.Delete(Idea);
        return deleteResult ? "idea Delete Successfully" : "idea not Delete Successfully";
    }

    public async Task<Idea?> GetById(int id, int userId)
    {
        return await _idea.GetById(id, userId);
    }

    public async Task<string> Update(int id, IdeaUpdateDto updateDto, int userId)
    {
        var FindIdea = await _idea.GetById(id,userId);
        if (FindIdea == null) return "Idea not Found";
        if (FindIdea.OwnerId != userId) return "You are not authorized to update this idea";
        FindIdea.Title = updateDto.Title;
        FindIdea.Description = updateDto.Description;
        FindIdea.ImageUrl = updateDto.ImageUrl;
        FindIdea.OwnerId = userId;
        FindIdea.CreateAt = DateOnly.FromDateTime(DateTime.Now);
        await _idea.UpdateAsync(FindIdea);

        await _appDbContext.ideas.Entry(FindIdea)
              .Collection(i => i.IdeaProducts)
              .LoadAsync();

        FindIdea.IdeaProducts.Clear();
        if (updateDto.ProductId != null && updateDto.ProductId.Count > 0)
        {
            foreach (var productId in updateDto.ProductId)
            {
                var ideaProduct = new IdeaProducts
                {
                    IdeaId = FindIdea.Id,
                    ProductId = productId
                };
                await _ideaProductService.Create(ideaProduct);
            }
        }
        return "idea Updated succefully";
    }
}