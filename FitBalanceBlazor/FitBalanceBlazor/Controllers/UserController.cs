using ClassLibrary1;
using FitBalanceBlazor.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace FitBalanceBlazor.Controllers;


[Route("Api/user")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Uzytkownik>>> GetUser(int id)
    {
        var response = await _userService.GetAllUserData(id);
        
        if(!response.Success)
            return BadRequest(response);
        return Ok(response);
    }
    
    [HttpPut("id")]
    public async Task<ActionResult<ServiceResponse<bool>>> UpdateUser(int id, [FromBody] Uzytkownik user)
    {
        var response = await _userService.UpdateUserData(id, user);
        
        if(!response.Success)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Uzytkownik>>>> GetAllUsersByIds()
    {
        var response = await _userService.SearchListUserData();
        
        if(!response.Success)
            return BadRequest(response);
        return Ok(response);
    }
}