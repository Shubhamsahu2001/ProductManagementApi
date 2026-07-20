using FluentValidation;
using ProductManagement.Application.DTOs.Products;

namespace ProductManagement.Application.Validators.Products;

public class CreateProductValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.ProductName)
            .NotEmpty()
            .WithMessage("Product Name is required.")
            .MaximumLength(255)
            .WithMessage("Product Name cannot exceed 255 characters.");
    }
}