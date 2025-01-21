using ClassLibrary1;
using FitBalanceBlazor.Services.EmployeeService;
using Microsoft.AspNetCore.Mvc;

namespace FitBalanceBlazor.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Pracownik>> GetPracownik(int id)
    {
        var response = await _employeeService.GetEmployeePracownikAsync(id);
        if(!response.Success)
            return BadRequest(response);
        return Ok(response);
    }
    
}