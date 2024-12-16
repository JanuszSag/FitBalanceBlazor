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
    public async Task<ActionResult> GetDietReportAsync(int Id)
    {
        var result = await _reportService.GetDietRaportsAsync(Id);
        return Ok(result);
    }
    
    [HttpGet("Water/{Id}")]
    public async Task<ActionResult> GetWaterReportAsync(int Id)
    {
        var result = await _reportService.GetWaterRaportsAsync(Id);
        return Ok(result);
    }
    
    [HttpGet("Weight/{Id}")]
    public async Task<ActionResult> GetWeightReportAsync(int Id)
    {
        var result = await _reportService.GetWeightRaportsAsync(Id);
        return Ok(result);
    }
}