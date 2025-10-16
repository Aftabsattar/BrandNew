using AutoMapper;
using Curate.Application.DTO.Auth;

namespace Curate.Application.Mapper;

public class UserRegister : Profile
{
    public UserRegister()
    {
        CreateMap<PasscodeDto, UserRegister>();
    }
}