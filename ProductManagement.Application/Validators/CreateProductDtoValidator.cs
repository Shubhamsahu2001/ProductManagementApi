using FluentValidation;
using ProductManagement.Application.DTOs.Products;

namespace ProductManagement.Application.Validators;

public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        RuleFor(x => x.ProductName)
            .NotEmpty()
            .WithMessage("Product Name is required.")
            .MaximumLength(255)
            .WithMessage("Product Name cannot exceed 255 characters.");
    }
}