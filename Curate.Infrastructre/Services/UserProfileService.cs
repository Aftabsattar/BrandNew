using System.Xml.XPath;
using AutoMapper;
using Curate.Application.DTO.Profile;
using Curate.Application.Interface;
using Curate.Application.IServices;
using Curate.Domain.Entities.Auth;

namespace Curate.Infrastructre.Services;

public class UserProfileService : IUserProfileService
{
    private readonly IMapper _mapper;
    private readonly IProfileRepository _profileRepository;
    public UserProfileService(IProfileRepository profileRepository, IMapper mapper)
    {
        _profileRepository = profileRepository;
        _mapper = mapper;
    }

    public async Task<string> Create(ProfileDto profile)
    {
        if(profile != null) 
        {
            var mapUser = _mapper.Map<User>(profile);
            var result = await _profileRepository.Create(mapUser);
            if (result) return "User Create Successfully";
        }
        return "User Not Create Successfully";
    }

    public async Task<string> Delete(int id)
    {
        var result = await _profileRepository.Delete(id);
        return result ? "User deleted Successfuly" : "User Not deleted Successfuly";
    }

    public async Task<List<User>> GetAll()
    {
        return await _profileRepository.GetAll();
    }

    public async Task<User> GetById(int id)
    {
        return await _profileRepository.GetById(id);
    }

    public async Task<string> Update(int id,ProfileDto user)
    {
        var FindUser = await _profileRepository.GetById(id);
        if (FindUser!= null && user != null)
        {
            var mapuser = _mapper.Map(user,FindUser);
            var result = await _profileRepository.Update(mapuser);
            if (result) return "User Profile Update successfulley";
        }
        return "User Profile Not Update successfulley";
    }
}