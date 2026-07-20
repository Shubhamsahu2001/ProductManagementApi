namespace ProductManagement.Application.DTOs.Products;

public class UpdateProductDto
{
    public int Id { get; set; }

    public string ProductName { get; set; } = string.Empty;
}