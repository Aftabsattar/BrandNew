using Curate.Application.Interface;
using Curate.Domain.Entities.Auth;
using Curate.Infrastructre.Context;
using Microsoft.EntityFrameworkCore;

namespace Curate.Infrastructre.Repository;

public class ProfileRepository : IProfileRepository
{
    private readonly AppDbContext _context;
    public ProfileRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Create(UserProfile profile)
    {
        var user = await _context.profiles.FindAsync(profile.id); 
        if (user != null) return false;
        await _context.AddAsync(profile);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var FindUser= await _context.profiles.FindAsync(id);
        if (FindUser == null) return false;
        _context.profiles.Remove(FindUser);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<UserProfile>> GetAll()
    {
        return await _context.profiles.ToListAsync();
    }

    public async Task<UserProfile> GetById(int id)
    {
        return await _context.profiles.FindAsync(id);
    }

    public async Task<bool> Update(UserProfile user)
    {
        var result = _context.profiles.Update(user);
        await _context.SaveChangesAsync();
        return result!= null ? true: false;
    }
}