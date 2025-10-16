using Curate.Application.Interface;
using Curate.Domain.Entities.Auth;
using Curate.Infrastructre.Context;
using Microsoft.EntityFrameworkCore;

namespace Curate.Infrastructre.Repository;

public class UserRegisterRepository : IUserRegisterRepository
{
    private readonly AppDbContext _appDbContext;
    public UserRegisterRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<UserRegister> Create(UserRegister user)
    {
        var finduser = await _appDbContext.users.FindAsync(user.Id);
        if (finduser != null) throw new Exception("User Already exist");
        var NewUserEntry = await _appDbContext.AddAsync(user);
        await _appDbContext.SaveChangesAsync();
        return NewUserEntry.Entity;
    }

    public async Task<UserRegister> GetByEmail(string email)
    {
        return await _appDbContext.users.FirstOrDefaultAsync(x=>x.Email== email);
    }

    public async Task<UserRegister> GetById(int id)
    {
        return await _appDbContext.users.FindAsync(id);
    }

    public async Task<bool> Update(UserRegister passcode)
    {
        _appDbContext.users.Update(passcode);
        await _appDbContext.SaveChangesAsync();
        return true;
    }
}