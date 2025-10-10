using Curate.Application.Interface.Auth;
using Curate.Domain.Entities.Auth;
using Curate.Infrastructre.Context;
using Microsoft.EntityFrameworkCore;

namespace Curate.Infrastructre.Repository;

public class UserRepository : IRegisterRepository
{
    private readonly AppDbContext _appDbContext;
    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<bool> Create(Register register)
    {
        var result = await _appDbContext.user.FindAsync(register.Id);
        if (result != null) return false;
        await _appDbContext.user.AddAsync(register);
        await _appDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var result = await _appDbContext.user.FindAsync(id);
        if (result != null)
        {
            _appDbContext.user.Remove(result);
            _appDbContext.SaveChanges();
            return true;
        }
        return false;
    }

    public async Task<List<Register>> GetAll()
    {
        return await _appDbContext.user.ToListAsync();
    }

    public async Task<Register> GetById(int id)
    {
        return await _appDbContext.user.FindAsync(id); 
    }

    public async Task<bool> Update(Register register)
    {
        var result = _appDbContext.user.Update(register);
        await _appDbContext.SaveChangesAsync();
        return result != null ? true : false;
    }
}