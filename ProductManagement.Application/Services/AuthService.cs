using ProductManagement.Application.DTOs.Auth;
using ProductManagement.Application.Interfaces;


namespace ProductManagement.Application.Services;

public class AuthService : IAuthService
{
    private readonly IJwtService _jwtService;

    public AuthService(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    public LoginResponseDto Login(LoginRequestDto request)
    {
        if (request.Username == "admin" && request.Password == "admin123")
        {
            return _jwtService.GenerateToken(request.Username, "Admin");
        }

        if (request.Username == "employee" && request.Password == "employee123")
        {
            return _jwtService.GenerateToken(request.Username, "Employee");
        }

        throw new UnauthorizedAccessException("Invalid username or password.");
    }
}