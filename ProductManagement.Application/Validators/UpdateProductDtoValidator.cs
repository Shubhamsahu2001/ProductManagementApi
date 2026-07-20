using FluentValidation;
using ProductManagement.Application.DTOs.Products;

namespace ProductManagement.Application.Validators;

public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Invalid Product Id.");

        RuleFor(x => x.ProductName)
            .NotEmpty()
            .WithMessage("Product Name is required.")
            .MaximumLength(255)
            .WithMessage("Product Name cannot exceed 255 characters.");
    }
}