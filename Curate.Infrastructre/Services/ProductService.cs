using AutoMapper;
using Curate.Application.DTO.Product;
using Curate.Application.Interface;
using Curate.Application.IServices;
using Curate.Domain.Entities;

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
    public async Task<string> Create(RequestDTo requestDTo)
    {
        if(requestDTo != null)
        {
            var productEntity = _mapper.Map<Product>(requestDTo);
            var result = await _product.Create(productEntity);
            return "Product created successfully";
        }
        return "Something went Wrong Product not created successfully";
    }

    public async Task<string> Delete(int id)
    {
        var result =  _product.GetById(id);
        if (result != null)
        {
            await _product.Delete(result.Result);
            return "Product deleted successfully";
        }
        return "Product not found";
    }

    public Task<string> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<string> Update(RequestDTo requestDTo)
    {
        throw new NotImplementedException();
    }
}