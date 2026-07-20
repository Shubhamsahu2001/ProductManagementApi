namespace ProductManagement.Application.DTOs.Products;

public class ProductResponseDto
{
    public int Id { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string CreatedBy { get; set; } = string.Empty;

    public DateTime CreatedOn { get; set; }
}