using AutoMapper;
using Curate.Application.DTO;
using Curate.Domain.Entities;

namespace Curate.Application.Mapper;

public class IdeaProfile:Profile
{

    public IdeaProfile()
    {
        CreateMap<RequestDto,Idea>();
        CreateMap<UpdateDto, Idea>();
    }
}