
using BrandNew.Application.DTO;
using BrandNew.Application.IServices;

namespace BrandNew.Infrastructre.Services;

public class IdeaService : IIdeaService
{
    public Task<string> Create(RequestDto requestDto)
    {
        
    }

    public Task<string> Delete(RequestDto requestDto)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetAll(RequestDto requestDto)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<string> Update(RequestDto requestDto)
    {
        throw new NotImplementedException();
    }

    public string SaveImage()
    {
        return "";
    }
}