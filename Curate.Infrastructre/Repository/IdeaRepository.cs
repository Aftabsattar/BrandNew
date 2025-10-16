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

    public async Task<bool> Delete(int id)
    {
        var existIdea = await _appDbContext.ideas.FindAsync(id);
        if (existIdea == null) return false;
         _appDbContext.ideas.Remove(existIdea);
        await _appDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<Idea>> GetAll()
    {
        return await _appDbContext.ideas.ToListAsync();
    }

    public async Task<Idea?> GetById(int id)
    {
        return await _appDbContext.ideas.FindAsync(id);
    }

    public async Task<bool> UpdateAsync(Idea idea)
    {
       _appDbContext.ideas.Update(idea);
       await _appDbContext.SaveChangesAsync();
       return true;
    }
}