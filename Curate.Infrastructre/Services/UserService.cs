using AutoMapper;
using Curate.Application.DTO.Auth;
using Curate.Application.Interface.Auth;
using Curate.Application.IServices;
using Curate.Domain.Entities.Auth;

namespace Curate.Infrastructre.Services;

public class UserService:IRegisterService
{
    private readonly IRegisterRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IRegisterRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<string> Delete(int id)
    {
        var result = await _userRepository.Delete(id);
        return result ? "User Delete succesfuly" : "User not Delete succesfuly";
    }

    public async Task<List<User>> GetAll() 
    {
        return await _userRepository.GetAll();
    }

    public async Task<User> GetById(int id)
    {
        return await _userRepository.GetById(id);
    }

    public async Task<string> Create(UserRegisterDto registerDto)
    {
        if (registerDto != null)
        {
            var user = _mapper.Map<User>(registerDto);
            var result = await _userRepository.Create(user);
            if (result) return "User Create Successfully";
        }
        return "User Already Exist";
    }

    public async Task<string> Update(int id, UpdateUserDto updateDto)
    {
        if (updateDto != null) 
        {
            var FindUser = await _userRepository.GetById(id);
            if (FindUser != null) 
            {
                var UpdatedUser = _mapper.Map(updateDto,FindUser);
                var result = await _userRepository.Update(UpdatedUser);
                if (result) return "User Updated Succefully";
            }
        }
        return "User NOt Updated Succefully";
    }
}