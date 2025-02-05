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
    
    [HttpPut]
    public async Task<ActionResult<ServiceResponse<bool>>> UpdateUser([FromBody] Uzytkownik user)
    {
        var response = await _userService.UpdateUserData(user);
        
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

    [HttpGet("diet/{dietId}")]
    public async Task<ActionResult<ServiceResponse<Uzytkownik>>> GetUserDietById(int dietId)
    {
        var response = await _userService.GetUserDataWithDiet(dietId);
        if (!response.Success)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpPut("AssignDiet/{userId}")]
    public async Task<ActionResult<ServiceResponse<bool>>> AssignDietToUser(int userId, [FromBody] int dietId)
    {
        var reponse = await _userService.AssignDiet(userId, dietId);
        if(!reponse.Success)
            return BadRequest(reponse);
        return Ok(reponse);
    }

    [HttpPut("assignWater/{userId}")]
    public async Task<ActionResult<ServiceResponse<bool>>> AssignWaterToUser(int userId, [FromBody] int water)
    {
        var response = await _userService.AssignWater(userId, water);
        if(!response.Success)
            return BadRequest(response);
        return Ok(response);
    }
    [HttpPut("assignWeight/{userId}")]
    public async Task<ActionResult<ServiceResponse<bool>>> AssignWeightToUser(int userId, [FromBody] int weight)
    {
        var response = await _userService.AssignWeight(userId, weight);
        if(!response.Success)
            return BadRequest(response);
        return Ok(response);
    }
}