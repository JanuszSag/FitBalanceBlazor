using FitBalanceBlazor.Models;
using FitBalanceBlazor.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitBalanceBlazor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DietController : ControllerBase
    {
        private IDietService _dietService;

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

        [HttpGet("{dietId}")]
        public async Task<ActionResult<Dieta>> GetDieta(int dietId)
        {
            var result = await _dietService.GetDietAsync(dietId);
            return Ok(result);
        }
    }
    
    
}

