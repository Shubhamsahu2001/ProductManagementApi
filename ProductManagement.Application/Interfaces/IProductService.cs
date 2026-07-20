using ProductManagement.Application.DTOs.Products;

namespace ProductManagement.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductListDto>> GetAllAsync(int page, int pageSize);

    Task<ProductResponseDto?> GetByIdAsync(int id);

    Task<int> CreateAsync(CreateProductDto dto);

    Task UpdateAsync(UpdateProductDto dto);

    Task DeleteAsync(int id);
}