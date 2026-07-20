using ProductManagement.Application.DTOs.Auth;

namespace ProductManagement.Application.Interfaces;

public interface IJwtService
{
    LoginResponseDto GenerateToken(string username, string role);
}