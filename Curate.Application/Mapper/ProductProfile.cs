using AutoMapper;
using Curate.Application.DTO.Product;
using Curate.Domain.Entities;

namespace Curate.Application.Mapper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<RequestDTo, Product>();
    }
}