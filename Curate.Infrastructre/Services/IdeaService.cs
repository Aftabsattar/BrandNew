
using Curate.Application.DTO;
using Curate.Application.Interface;
using Curate.Application.IServices;
using Curate.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;

namespace Curate.Infrastructre.Services;

public class IdeaService : IIdeaService
{
    private readonly IIdeaRepository _idea;
    public IdeaService(IIdeaRepository idea)
    {
        _idea = idea; 
    }
    public async Task<string> Create(RequestDto requestDto)
    {
        var Save = new Idea
        {
            Title = requestDto.Title,
            Description = requestDto.Description,
            ImageUrl = requestDto.UploadImage != null ? await SaveImage(requestDto.UploadImage): string.Empty,
        };
        
        var result = await _idea.CreatAsync(Save);
          if (result)
            return "Idea created succefulley";
        return "Idea Not created succefulley";
    }

    public string Delete(RequestDto requestDto)
    {
        throw new NotImplementedException();
    }

    public string GetAll(RequestDto requestDto)
    {
        throw new NotImplementedException();
    }

    public string GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<string> Update( int id, UpdateDto updatetDto)
    {
        var FindIdea= await _idea.GetById(id);
        if (FindIdea == null) return "Idea not Found";
        FindIdea.Title = updatetDto.Title;
        FindIdea.Description = updatetDto.Description;
        FindIdea.ImageUrl = updatetDto.MainImage != null ? await SaveImage(updatetDto.MainImage): string.Empty;
        var result = _idea.UpdateAsync(FindIdea);
        if (result) return "Idea Updated Succefully";
        return "idea not Updated succefully";
    }

    public async Task<string> SaveImage(IFormFile formFile)
    {
        var FileName = Path.GetFileName(formFile.FileName);
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\image", FileName);
        using (var fileStream = new FileStream(filePath, FileMode.Create)) 
        {
            await formFile.CopyToAsync(fileStream);
        }
            return filePath;
    }
}