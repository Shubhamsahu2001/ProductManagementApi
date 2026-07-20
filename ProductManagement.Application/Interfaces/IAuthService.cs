using ProductManagement.Application.DTOs.Auth;

namespace ProductManagement.Application.Interfaces;

public interface IAuthService
{
    LoginResponseDto Login(LoginRequestDto request);
}