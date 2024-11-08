using FitBalanceBlazor.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace FitBalanceBlazor.Controllers;


[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    //[HttpPost("login")]
    //public IActionResult Login
    
}