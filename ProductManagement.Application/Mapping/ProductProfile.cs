using AutoMapper;
using ProductManagement.Application.DTOs.Products;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductResponseDto>();

        CreateMap<Product, ProductListDto>();

        CreateMap<CreateProductDto, Product>();

        CreateMap<UpdateProductDto, Product>();
    }
}