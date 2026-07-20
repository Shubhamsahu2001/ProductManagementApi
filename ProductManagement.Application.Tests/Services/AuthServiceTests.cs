using FluentAssertions;
using Moq;
using ProductManagement.Application.DTOs.Auth;
using ProductManagement.Application.Interfaces;
using ProductManagement.Application.Services;
using Xunit;

namespace ProductManagement.Application.Tests.Services;

public class AuthServiceTests
{
    private readonly Mock<IJwtService> _jwtServiceMock;
    private readonly AuthService _authService;

    public AuthServiceTests()
    {
        _jwtServiceMock = new Mock<IJwtService>();
        _authService = new AuthService(_jwtServiceMock.Object);
    }

    [Fact]
    public void Login_ShouldReturnToken_WhenCredentialsAreValid()
    {
        // Arrange
        var request = new LoginRequestDto
        {
            Username = "admin",
            Password = "admin123"
        };

        var response = new LoginResponseDto
        {
            AccessToken = "dummy-token",
            Expiration = DateTime.UtcNow.AddMinutes(30)
        };

        _jwtServiceMock
    .Setup(j => j.GenerateToken("admin", "Admin"))
    .Returns(response);

        // Act
        var result = _authService.Login(request);

        // Assert
        result.AccessToken.Should().Be("dummy-token");
    }

    [Fact]
    public void Login_ShouldThrowUnauthorizedException_WhenCredentialsAreInvalid()
    {
        // Arrange
        var request = new LoginRequestDto
        {
            Username = "wrong",
            Password = "wrong"
        };

        // Act
        Action act = () => _authService.Login(request);

        // Assert
        act.Should().Throw<UnauthorizedAccessException>();
    }
}