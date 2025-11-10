using AutoMapper;
using Curate.Application.DTO.Idea;
using Curate.Application.DTO.Product;
using Curate.Domain.Entities;

namespace Curate.Application.Mapper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<RequestDto, Product>();
        CreateMap<RequestDto, Product>();
    }
}