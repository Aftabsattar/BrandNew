using AutoMapper;
using Curate.Application.DTO.Profile;

namespace Curate.Application.Mapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<ProfileDto, UserProfile>();
        CreateMap<ProfileDto, UserProfile>();
    }
}