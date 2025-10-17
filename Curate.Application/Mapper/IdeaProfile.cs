using AutoMapper;
using Curate.Application.DTO.Idea;
using Curate.Domain.Entities;

namespace Curate.Application.Mapper;

public class IdeaProfile: Profile
{
    public IdeaProfile()
    {
        CreateMap<IdeaRequestDto,Idea>();
        CreateMap<IdeaUpdateDto, Idea>();
    }
}