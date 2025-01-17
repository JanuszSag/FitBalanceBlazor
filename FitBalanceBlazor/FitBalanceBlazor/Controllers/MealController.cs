using FitBalanceBlazor.Services.MealService;
using Microsoft.AspNetCore.Mvc;

namespace FitBalanceBlazor.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MealController : ControllerBase
{
    private readonly IMealService _mealService;

    public MealController(IMealService mealService)
    {
        _mealService = mealService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Danie>>> GetMeals()
    {
        var response = await _mealService.GetAllMealsAsync();
        if(!response.Success)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Danie>> GetMeal(int id)
    {
        return await _mealService.GetMealByIdAsync(id);
    }
    
}