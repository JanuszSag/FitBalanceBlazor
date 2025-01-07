using ClassLibrary1;
using FitBalanceBlazor.Services.ReportService;
using Microsoft.AspNetCore.Mvc;

namespace FitBalanceBlazor.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet("Diet/{Id}")]
    public async Task<ActionResult<ServiceResponse<List<Raport>>>> GetDietReportAsync(int Id)
    {
        
        var response = await _reportService.GetDietRaportsAsync(Id);
        if(!response.Success)
            return BadRequest(response);
        return Ok(response);
    }
    
    [HttpGet("Water/{Id}")]
    public async Task<ActionResult<ServiceResponse<List<Wypita_woda>>>> GetWaterReportAsync(int Id)
    {
        var response = await _reportService.GetWaterRaportsAsync(Id);
        if(!response.Success)
            return BadRequest(response);
        return Ok(response);
    }
    
    [HttpGet("Weight/{Id}")]
    public async Task<ActionResult<ServiceResponse<List<Pomiar_wagi>>>> GetWeightReportAsync(int Id)
    {
        var response = await _reportService.GetWeightRaportsAsync(Id);
        if(!response.Success)
            return BadRequest(response);
        return Ok(response);
    }
}