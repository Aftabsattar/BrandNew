using Curate.Application.DTO.Search;
using Curate.Application.Interface;
using Curate.Domain.Entities;
using Curate.Domain.Search;
using Curate.Infrastructre.Context;
using Microsoft.EntityFrameworkCore;

namespace Curate.Infrastructre.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _appDbContext;
    public ProductRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<bool> Create(Product product)
    {
        var productId = await _appDbContext.products.FindAsync(product.Id);
        if (productId != null) return false; 
        await _appDbContext.products.AddAsync(product);
        await _appDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
       var result = await _appDbContext.products.FindAsync(id);
       if (result != null)
        {
            _appDbContext.products.Remove(result);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
       return false;
    }

    public async Task<IQueryable<Product>> GetAll(string? textQuery, string? sortOrder, string? sortBy)
    {
        var query = _appDbContext.products.AsQueryable();
        if(!string.IsNullOrEmpty(textQuery))
        {
            query = query.Where(x => x.Title.Contains(textQuery) || 
            x.Description.Contains(textQuery) || 
            x.RetailerName.Contains(textQuery));
        }
        if (!string.IsNullOrEmpty(sortOrder))
        {
            if (sortBy?.ToUpper() == "DESC") query = query.OrderByDescending(x => EF.Property<object>(x, sortOrder));
            else query = query.OrderBy(x => EF.Property<object>(x, sortOrder));
        }
        return query;
    }

    public async Task<List<int>> GetAllId()
    {
        return await _appDbContext.products.Select(p=> p.Id).ToListAsync();
    }

    public async Task<Product> GetById(int id)
    {
        return await _appDbContext.products.FirstOrDefaultAsync(x=> x.Id == id);
    }

    public async Task<bool> Update(Product product)
    {
        var result = _appDbContext.products.Update(product);
        if (result != null)
        {
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
