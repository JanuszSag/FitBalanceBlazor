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

    [HttpGet]
    public async Task<ActionResult<List<Pracownik>>> GetPracownik()
    {
        var response = await _employeeService.GetAllEmployeesAsync();
        if(!response.Success)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<bool>>> AddPracownik([FromBody] PracownikDTO pracownik)
    {
        var response = await _employeeService.AddEmployeeAsync(pracownik);
        if(!response.Success)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpPost("Address")]
    public async Task<ActionResult<ServiceResponse<bool>>> AddAddress([FromBody] AdresDTO adress)
    {
        var response = await _employeeService.AddAddressAsync(adress);
        if(!response.Success)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpGet("Addresses")]
    public async Task<ActionResult<ServiceResponse<List<Adres>>>> GetAllAddresses()
    {
        var response = await _employeeService.GetAllAddressesAsync();
        if(!response.Success)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<bool>>> DeleteEmployee(int id)
    {
        var response = await _employeeService.DeleteEmployeeAsync(id);
        if(!response.Success)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<bool>>> UpdateEmployee([FromBody] PracownikDTO emp)
    {
        var response = await _employeeService.UpdateEmployeeAsync(emp);
        if(!response.Success)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpDelete("Address/{id}")]
    public async Task<ActionResult<ServiceResponse<bool>>> DeleteAddress(int id)
    {
        var response = await _employeeService.DeleteAddressAsync(id);
        if(!response.Success)
            return BadRequest(response);
        return Ok(response);
    }

}