using Curate.Application.DTO.Idea;
using Curate.Application.DTO.Product;
using Curate.Application.Interface;
using Curate.Domain.Entities;
using Curate.Infrastructre.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Curate.Infrastructre.Repository;

public class IdeaProductRepository : IIdeaProductRepository
{
    private readonly AppDbContext _dbContext;
    public IdeaProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Create(IdeaProducts idea)
    {
        await _dbContext.ideaProducts.AddAsync(idea);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<IdeaDto>> GetAll(int userId)
    {
        var ideas = await _dbContext.ideaProducts
            .Where(ip => ip.Idea.OwnerId == userId)
            .Include(ip => ip.Idea)
            .Include(ip => ip.Product)
            .ToListAsync();

        var result = ideas
            .GroupBy(ip => ip.Idea)
            .Select(g => new IdeaDto
            {
                Id = g.Key.Id,                     
                Title = g.Key.Title,
                Description = g.Key.Description,
                ImageUrl = g.Key.ImageUrl,

                Products = g.Select(ip => new ProductDto
                {
                    Id = ip.Product.Id,            
                    Title = ip.Product.Title,
                    Price = ip.Product.Price,
                    RetailerName = ip.Product.RetailerName,
                    Description = ip.Product.Description
                }).ToList()
            })
            .ToList();

        return result;
    }

    public async Task<IdeaDto?> GetById(int id, int userId)
    {
        var ideas = await _dbContext.ideaProducts
    .Where(ip => ip.Idea.OwnerId == userId && ip.Idea.Id == id)
    .Include(ip => ip.Idea)
    .Include(ip => ip.Product)
    .ToListAsync();

        var result = ideas
    .GroupBy(ip => ip.Idea)
    .Select(g => new IdeaDto
    {
        Id = g.Key.Id,
        Title = g.Key.Title,
        Description = g.Key.Description,
        ImageUrl = g.Key.ImageUrl,

        Products = g.Select(ip => new ProductDto
        {
            Id = ip.Product.Id,
            Title = ip.Product.Title,
            Price = ip.Product.Price,
            RetailerName = ip.Product.RetailerName,
            Description = ip.Product.Description
        }).ToList()
    })
    .FirstOrDefault();

        return result;
    }

    public async Task<bool> Update(IdeaProducts ideaProducts)
    {
        _dbContext.ideaProducts.Update(ideaProducts);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}