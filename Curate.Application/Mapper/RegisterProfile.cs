using AutoMapper;
using Curate.Application.DTO.Auth;
using Curate.Domain.Entities.Auth;

namespace Curate.Application.Mapper;

public class RegisterProfile:Profile
{
    public RegisterProfile()
    {
        CreateMap<UserRegisterDto,Register>();
        CreateMap<UserUpdateDto, Register>();
    }
}