using Curate.Application.Interface;
using Curate.Infrastructre.Context;

namespace Curate.Infrastructre.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _appDbContext;
    public ProductRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public Task<string> Create()
    {
        throw new NotImplementedException();
    }

    public Task<string> Delete()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<string> Update()
    {
        throw new NotImplementedException();
    }
}
