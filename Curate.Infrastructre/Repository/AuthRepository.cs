using Curate.Application.Interface.Auth;
using Curate.Domain.Entities.Auth;
using Curate.Infrastructre.Context;
using Microsoft.EntityFrameworkCore;

namespace Curate.Infrastructre.Repository;

public class AuthRepository : IAuthRepository
{
    private readonly AppDbContext _appDbContext;
    public AuthRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<bool> Create(User otp)
    {
        var result = await _appDbContext.users.FindAsync(otp.Id);
        if (result != null) return false;
        await _appDbContext.users.AddAsync(otp);
        await _appDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var result = await _appDbContext.users.FindAsync(id);
        if (result != null)
        {
            _appDbContext.users.Remove(result);
            _appDbContext.SaveChanges();
            return true;
        }
        return false;
    }

    public async Task<List<User>> GetAll()
    {
        return await _appDbContext.users.ToListAsync();
    }
    public async Task<User?> GetByEmail(string email)
    {
        return await _appDbContext.users.FirstOrDefaultAsync(x=> x.Email==email); 
    }

    public async Task Update(User user)
    {
        _appDbContext.users.Update(user);
        await _appDbContext.SaveChangesAsync();
    }
}