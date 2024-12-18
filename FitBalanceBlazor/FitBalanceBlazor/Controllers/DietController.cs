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
        public async Task<ActionResult<List<Dieta>>> GetDiets()
        {
            var result = await _dietService.GetAllDietsAsync();
            return Ok(result);
        }

        [HttpPost("id")]
        public async Task<ActionResult<List<Dieta>>> GetDietById(List<int> id)
        {
            var result = await _dietService.GetAllDietsByIdAsync(id);
            return Ok(result);
        }
        
        [HttpGet("Category/{id}")]
        public async Task<ActionResult<List<Dieta>>> GetDietsByCategory(int id)
        {
            return await _dietService.GetAllDietsByCategoryIdAsync(id);
        }

        [HttpGet("{dietId}")]
        public async Task<ActionResult<Dieta>> GetDieta(int dietId)
        {
            var result = await _dietService.GetDietAsync(dietId);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDiet(int id)
        {
            _dietService.RemoveDietAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> AddDiet(DietaDTO dieta)
        {
            _dietService.AddDiet(dieta);
            return Ok();
        }

        [HttpPut("{dietId}")]
        public async Task<ActionResult> UpdateDiet(String dietId,[FromBody] List<Danie> meals)
        {
            if(await _dietService.AddMealsToDiet(Int32.Parse(dietId), meals))
                return Ok("Zaktualizowano liste dan");
            return NotFound("Nie znaleziono diety");
        }
    }
    
    


