using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.DTOs.Auth;
using ProductManagement.Application.Interfaces;

namespace ProductManagement.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequestDto request)
    {
        var response = _authService.Login(request);

        return Ok(response);
    }
}