using Curate.Application.DTO;
using Microsoft.AspNetCore.Http;

namespace Curate.Application.IServices;

public interface IIdeaService
{
    Task<string> Create(RequestDto requestDto);
    Task<string> Update(int id, UpdateDto updatetDto);
    string Delete(RequestDto requestDto);
    string GetAll(RequestDto requestDto);
    string GetById(int id);
    Task<string> ProcessImage(IFormFile formFile);
}