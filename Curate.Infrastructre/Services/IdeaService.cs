using AutoMapper;
using Curate.Application.DTO.Idea;
using Curate.Application.Interface;
using Curate.Application.IServices;
using Curate.Domain.Entities;

namespace Curate.Infrastructre.Services;

public class IdeaService : IIdeaService
{
    private readonly IIdeaRepository _idea;
    private readonly IMapper _mapper;
    public IdeaService(IIdeaRepository idea, IMapper mapper)
    {
        _idea = idea;
        _mapper = mapper;
    }
    public async Task<string> Create(IdeaRequestDto requestDto, int userId)
    {
        var idea = new Idea
        {
            Title = requestDto.Title,
            Description = requestDto.Description,
            ImageUrl = requestDto.ImageUrl,
            CreateAt = requestDto.CreateAt,
            OwnerId = userId
        };
        var result = await _idea.CreatAsync(idea);
        return result ? "Idea created succefulley" : "Idea Not created succefulley";
    }

    public async Task<string> DeleteAsync(int id,int currentUserId)
    {
        var Idea = await _idea.GetById(id);
        if (Idea == null) return "Idea not Found";
        if (Idea.OwnerId != currentUserId) return "You are not authorized to delete this idea";
        var deleteResult = await _idea.Delete(Idea);
        return deleteResult ? "idea Delete Successfully" : "idea not Delete Successfully";
    }

    public async Task<List<Idea>> GetAll()
    {
         return await _idea.GetAll();

    }

    public async Task<Idea?> GetById(int id)
    {
        return await _idea.GetById(id);
    }

    public async Task<string> Update(int id, IdeaUpdateDto updateDto, int currentUserId)
    {
        var FindIdea = await _idea.GetById(id);
        if (FindIdea == null) return "Idea not Found";
        if (FindIdea.OwnerId != currentUserId) return "You are not authorized to update this idea";
        var Updatedidea = _mapper.Map(updateDto, FindIdea);
        var result = await _idea.UpdateAsync(Updatedidea);
        return result ? "Idea Updated Succefully" : "idea not Updated succefully";
    }
}