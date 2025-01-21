using ClassLibrary1;

namespace FitBalanceBlazor.Services.EmployeeService;

public interface IEmployeeService
{
    Task<ServiceResponse<Pracownik>> GetEmployeePracownikAsync(int id);
}