using degree_management.application.Dtos.Requests.Auth;
using degree_management.application.Services;
using Microsoft.AspNetCore.Mvc;

namespace degree_management.api.Controllers;
[Route("api/auth")]
[ApiController]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestDto model)
    {
        var result = await _authService.RegisterAsync(model);
        return Ok(result);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDto model)
    {
        var result = await _authService.LoginAsync(model);
        return Ok(result);
    }
}