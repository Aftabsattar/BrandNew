using System.Net.Http.Headers;
using System.Threading.Tasks;
using Azure.Core;
using Curate.Application.Interface;
using Curate.Domain.Entities;
using Curate.Infrastructre.Context;

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

    public Task<bool> DeleteAsync(Idea idea)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Idea> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<Idea?> GetById(int id)
    {
        return await _appDbContext.ideas.FindAsync(id);
    }

    public bool UpdateAsync(Idea idea)
    {
        _appDbContext.ideas.Update(idea);
        _appDbContext.SaveChanges();
        return true;
    }
}
