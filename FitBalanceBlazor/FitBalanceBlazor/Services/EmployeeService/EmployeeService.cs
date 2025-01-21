using ClassLibrary1;
using FitBalanceBlazor.Context;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor.Services.EmployeeService;

public class EmployeeService(MyDbContext context) : IEmployeeService
{
    public async Task<ServiceResponse<Pracownik>> GetEmployeePracownikAsync(int id)
    {
        var response = new ServiceResponse<Pracownik>();
        var employee = await context.Pracownik.FirstOrDefaultAsync(e => e.id_uzytkownik==id);
        if (employee is null)
        {
            response.Success = false;
            response.Message = "Cannot find employee.";
            return response;
        }
        response.Data = employee;
        response.Success = true;
        return response;
    }
}