using AutoMapper;
using ProductManagement.Application.DTOs.Products;
using ProductManagement.Application.Interfaces;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Exceptions;

namespace ProductManagement.Application.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductListDto>> GetAllAsync(int page, int pageSize)
    {
        var products = await _unitOfWork.Products.GetAllAsync();

        var pagedProducts = products
            .Skip((page - 1) * pageSize)
            .Take(pageSize);

        return _mapper.Map<IEnumerable<ProductListDto>>(pagedProducts);
    }

    public async Task<ProductResponseDto?> GetByIdAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);

        if (product == null)
            return null;

        return _mapper.Map<ProductResponseDto>(product);
    }

    public async Task<int> CreateAsync(CreateProductDto dto)
    {
        var product = _mapper.Map<Product>(dto);

        product.CreatedBy = "System";

        product.CreatedOn = DateTime.UtcNow;

        await _unitOfWork.Products.AddAsync(product);

        await _unitOfWork.SaveChangesAsync();

        return product.Id;
    }

    public async Task UpdateAsync(UpdateProductDto dto)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(dto.Id);

        if (product == null)
            throw new ProductNotFoundException(dto.Id);

        product.ProductName = dto.ProductName;

        product.ModifiedBy = "System";

        product.ModifiedOn = DateTime.UtcNow;

        _unitOfWork.Products.Update(product);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);

        if (product == null)
            throw new ProductNotFoundException(id);

        _unitOfWork.Products.Delete(product);

        await _unitOfWork.SaveChangesAsync();
    }
}