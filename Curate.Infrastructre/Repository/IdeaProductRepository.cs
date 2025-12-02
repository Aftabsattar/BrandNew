using Curate.Application.Interface;
using Curate.Domain.Entities;
using Curate.Infrastructre.Context;

namespace Curate.Infrastructre.Repository;

public class IdeaProductRepository : IIdeaProductRepository
{
    private readonly AppDbContext _dbContext;
    public IdeaProductRepository (AppDbContext dbContext)
    {
         _dbContext = dbContext;
    }
    public async Task<bool> Create(IdeaProducts idea)
    {
        await _dbContext.ideaProducts.AddAsync(idea);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public bool Delete()
    {
        throw new NotImplementedException();
    }

    public bool GetAll()
    {
        throw new NotImplementedException();
    }

    public bool GetById()
    {
        throw new NotImplementedException();
    }

    public bool Update()
    {
        throw new NotImplementedException();
    }
}