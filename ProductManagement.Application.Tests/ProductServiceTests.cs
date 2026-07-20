using AutoMapper;
using FluentAssertions;
using Moq;
using ProductManagement.Application.DTOs.Products;
using ProductManagement.Application.Interfaces;
using ProductManagement.Application.Mapping;
using ProductManagement.Application.Services;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Exceptions;
using Xunit;

namespace ProductManagement.Application.Tests.Services;

public class ProductServiceTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly IMapper _mapper;
    private readonly ProductService _productService;

    public ProductServiceTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _productRepositoryMock = new Mock<IProductRepository>();

        _unitOfWorkMock
            .Setup(u => u.Products)
            .Returns(_productRepositoryMock.Object);

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductProfile>();
        });

        _mapper = config.CreateMapper();

        _productService = new ProductService(
            _unitOfWorkMock.Object,
            _mapper);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllProducts()
    {
        // Arrange
        var products = new List<Product>
        {
            new Product { Id = 1, ProductName = "Laptop" },
            new Product { Id = 2, ProductName = "Mouse" }
        };

        _productRepositoryMock
            .Setup(r => r.GetAllAsync())
            .ReturnsAsync(products);

        // Act
        var result = await _productService.GetAllAsync(1, 10);

        // Assert
        result.Should().HaveCount(2);
        result.First().ProductName.Should().Be("Laptop");
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnProduct_WhenProductExists()
    {
        // Arrange
        var product = new Product
        {
            Id = 1,
            ProductName = "Laptop"
        };

        _productRepositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(product);

        // Act
        var result = await _productService.GetByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result!.ProductName.Should().Be("Laptop");
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenProductDoesNotExist()
    {
        // Arrange
        _productRepositoryMock
            .Setup(r => r.GetByIdAsync(999))
            .ReturnsAsync((Product?)null);

        // Act
        var result = await _productService.GetByIdAsync(999);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task CreateAsync_ShouldSaveProduct()
    {
        // Arrange
        var dto = new CreateProductDto
        {
            ProductName = "Keyboard"
        };

        _productRepositoryMock
            .Setup(r => r.AddAsync(It.IsAny<Product>()))
            .Returns(Task.CompletedTask);

        _unitOfWorkMock
            .Setup(u => u.SaveChangesAsync())
            .ReturnsAsync(1);

        // Act
        await _productService.CreateAsync(dto);

        // Assert
        _productRepositoryMock.Verify(
            r => r.AddAsync(It.IsAny<Product>()),
            Times.Once);

        _unitOfWorkMock.Verify(
            u => u.SaveChangesAsync(),
            Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldThrowException_WhenProductDoesNotExist()
    {
        // Arrange
        _productRepositoryMock
            .Setup(r => r.GetByIdAsync(10))
            .ReturnsAsync((Product?)null);

        // Act
        Func<Task> act = async () =>
            await _productService.DeleteAsync(10);

        // Assert
        await act.Should()
            .ThrowAsync<ProductManagement.Domain.Exceptions.ProductNotFoundException>();
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateProduct_WhenProductExists()
    {
        // Arrange
        var product = new Product
        {
            Id = 1,
            ProductName = "Old Name"
        };

        var dto = new UpdateProductDto
        {
            Id = 1,
            ProductName = "New Name"
        };

        _productRepositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(product);

        _unitOfWorkMock
            .Setup(u => u.SaveChangesAsync())
            .ReturnsAsync(1);

        // Act
        await _productService.UpdateAsync(dto);

        // Assert
        product.ProductName.Should().Be("New Name");

        _productRepositoryMock.Verify(r => r.Update(product), Times.Once);

        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldThrowException_WhenProductDoesNotExist()
    {
        // Arrange
        var dto = new UpdateProductDto
        {
            Id = 100,
            ProductName = "Laptop"
        };

        _productRepositoryMock
            .Setup(r => r.GetByIdAsync(100))
            .ReturnsAsync((Product?)null);

        // Act
        Func<Task> act = async () =>
            await _productService.UpdateAsync(dto);

        // Assert
        await act.Should()
            .ThrowAsync<ProductNotFoundException>();
    }
}