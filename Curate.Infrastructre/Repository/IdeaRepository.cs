using Curate.Application.DTO.Idea;
using Curate.Application.DTO.Product;
using Curate.Application.Interface;
using Curate.Domain.Entities;
using Curate.Infrastructre.Context;
using Microsoft.EntityFrameworkCore;

namespace Curate.Infrastructre.Repository;

public class IdeaRepository : IIdeaRepository
{
    private readonly AppDbContext _appDbContext;
    public IdeaRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<bool> CreatAsync(Idea idea)
    {
        var res = await _appDbContext.ideas.AddAsync(idea);
        await _appDbContext.SaveChangesAsync();
        if (res != null)
            return true;
        return false;
    }

    //public async Task<bool> Delete(IdeaDto idea)
    //{
    //    if (idea == null) return false;
    //    _appDbContext.ideas.Remove(idea);
    //    await _appDbContext.SaveChangesAsync();
    //    return true;
    //}

    public async Task<Idea?> GetById(int id, int userId)
    {
        return await _appDbContext.ideas
        .Include(i => i.IdeaProducts)
        .ThenInclude(ip => ip.Product)      
        .FirstOrDefaultAsync(i => i.Id == id && i.OwnerId == userId);
    }

    public async Task<bool> UpdateAsync(Idea idea)
    {
        _appDbContext.ideas.Update(idea);
        await _appDbContext.SaveChangesAsync();
        return true;
    }
}