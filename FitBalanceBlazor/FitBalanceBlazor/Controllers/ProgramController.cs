using FitBalanceBlazor.Services.ProgramService;
using Microsoft.AspNetCore.Mvc;

namespace FitBalanceBlazor.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProgramController : ControllerBase
{
    private readonly IProgramService _programService;

    public ProgramController(IProgramService programService)
    {
        _programService = programService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Programy>>> GetPrograms()
    {
        return await _programService.GetProgramsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Programy>> GetProgram(int id)
    {
        return await _programService.GetProgramByIdAsync(id);
    }
}