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
    public async Task<bool> Create(UserRegister user)
    {
        var finduser = await _appDbContext.users.FindAsync(user.Id);
        if (finduser != null) return false;
        await _appDbContext.AddAsync(user);
        await _appDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<UserRegister> GetByEmail(string email)
    {
        return await _appDbContext.users.FirstOrDefaultAsync(x=>x.Email== email);
    }

    public async Task<bool> Update(UserRegister passcode)
    {
        _appDbContext.users.Update(passcode);
        await _appDbContext.SaveChangesAsync();
        return true;
    }
}