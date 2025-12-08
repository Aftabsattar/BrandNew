using AutoMapper;
using Curate.Application.DTO.Product;
using Curate.Application.Interface;
using Curate.Application.IServices;
using Curate.Domain.Entities;
using Curate.Domain.Search;

namespace Curate.Infrastructre.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _product;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository product, IMapper mapper)
    {
        _product = product;
        _mapper = mapper;
    }
    public async Task<string> Create(RequestDTo requestDTo, int userId)
    {
        if(requestDTo != null)
        {
            var productEntity = _mapper.Map<Product>(requestDTo);
            var result = await _product.Create(productEntity);
            return "Product created successfully";
        }
        return "Something went Wrong Product not created successfully";
    }

    public async Task<string> Delete(int id, int userId)
    {
        var result =  _product.GetById(id);
        if (result != null)
        {
            await _product.Delete(result.Id);
            return "Product deleted successfully";
        }
        return "Product not found";
    }

    public async Task<PagedResult<Product>> GetAll(string? textQuery, string? sortOrder, string? sortBy, int PageNumber, int PageSize)
    {
        var query = await _product.GetAll(textQuery, sortOrder, sortBy);
        var TotalRecords = query.Count();
        var Item = query
            .Skip((PageNumber - 1) * PageSize)
            .Take(PageSize)
            .ToList();

            var response = new PagedResult<Product>
            {
                TotalRecords = TotalRecords,
                Items = Item,
                TotalPage = (int)Math.Ceiling((double)TotalRecords / PageSize),
                PageNumber = PageNumber,
                PageSize = PageSize
            };
        return response;
    }

    public async Task<List<int>> GetAllId()
    {
        return await _product.GetAllId();
    }

    public async Task<Product> GetById(int id)
    {
        return await _product.GetById(id);
    }

    public async Task<string> Update(int id ,UpdateRequest updateRequest, int userId)
    {
        var result = await _product.GetById(id);
        if (result != null)
        {
            result.Title = updateRequest.Title;
            result.Description = updateRequest.Description;
            result.Price = updateRequest.Price;
            result.UpdatedAt = DateTime.Now;
            result.RetailerName= updateRequest.RetailerName;
            var updateProduct = await _product.Update(result);
            if (updateProduct) return "Product Update Succcesfuly";
        }
        return "Something Went Wrong Product not Update Succcesfuly";
    }
}