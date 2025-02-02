using ClassLibrary1;
using FitBalanceBlazor.Services.AuthService;
using Microsoft.AspNetCore.Authorization;
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

    [HttpPost("login")]
    public async Task<ActionResult<ServiceResponse<string>>> Login([FromBody] LoginModel loginModel)
    {
        var response = await _authService.Login(loginModel);

        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<ActionResult<ServiceResponse<int>>> Register([FromBody] RegisterModel registerModel)
    {
        var response = await _authService.Register(registerModel);

        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    //[HttpPost("change-password"), Authorize]
    //public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword([FromBody] string newPassword)
    //{
    //    var userId = _authService.GetUserId();
    //}
    
}