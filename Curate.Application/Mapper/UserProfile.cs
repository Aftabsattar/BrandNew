using AutoMapper;
using Curate.Application.DTO.Profile;
using Curate.Domain.Entities.Auth;

namespace Curate.Application.Mapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<ProfileDto, User>();
        CreateMap<ProfileDto, User>();
    }
}