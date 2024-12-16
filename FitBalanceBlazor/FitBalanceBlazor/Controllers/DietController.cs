using ClassLibrary1;
using FitBalanceBlazor.Client.Pages.AddDiet;
using FitBalanceBlazor.Models;
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
            _dietService.AddDietAsync(dieta);
            return Ok();
        }
    }
    
    


