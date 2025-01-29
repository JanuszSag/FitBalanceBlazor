using ClassLibrary1;
using FitBalanceBlazor.Client.Pages.AddDiet;
using FitBalanceBlazor.Services;
using FitBalanceBlazor.Services.DietService;
using Microsoft.AspNetCore.Mvc;

namespace FitBalanceBlazor.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class DietController : ControllerBase
    {
        private readonly IDietService _dietService;

        public DietController(IDietService dietService)
        {
            _dietService = dietService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Dieta>>>> GetDiets()
        {
            var response = await _dietService.GetAllDietsAsync();
            return Ok(response);
        }

        [HttpPost("id")]
        public async Task<ActionResult<ServiceResponse<List<Dieta>>>> GetDietById(List<int> id)
        {
            var result = await _dietService.GetAllDietsByIdAsync(id);
            if(!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        
        [HttpGet("Category/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Dieta>>>> GetDietsByCategory(int id)
        {
            var result = await _dietService.GetAllDietsByCategoryIdAsync(id);
            if(!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("{dietId}")]
        public async Task<ActionResult<ServiceResponse<Dieta>>> GetDieta(int dietId)
        {
            var result = await _dietService.GetDietAsync(dietId);
            if(!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteDiet(int id)
        {
            var result = await _dietService.RemoveDietAsync(id);
            if(!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddDiet(DietaDTO dieta)
        {
            var result = await _dietService.AddDiet(dieta);
            if(!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateMeals/{dietId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdateListOfMeals(int dietId, [FromBody] List<int> meals)
        {
            var response = _dietService.AddMealsToDiet(dietId, meals);
            if (!response.Result.Success)
            {
                return BadRequest(response.Result.Message);
            }
            return Ok("Zaktualizowano liste dan");
        }

        [HttpPut]
        [Route("UpdateMealsInDiet/{dietId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdateListOfMealsInDiet(int dietId,
            [FromBody] List<int> meals)
        {
            var response = _dietService.UpdateMealsInUserDiet(dietId, meals);
            if(!response.Result.Success)
                return BadRequest(response.Result.Message);
            return Ok("Zaktualizowano liste dan");
        }
    }
    
    


