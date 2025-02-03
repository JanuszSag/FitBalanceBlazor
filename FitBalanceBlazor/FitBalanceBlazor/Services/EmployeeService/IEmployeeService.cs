using ClassLibrary1;

namespace FitBalanceBlazor.Services.EmployeeService;

public interface IEmployeeService
{
    Task<ServiceResponse<Pracownik>> GetEmployeePracownikAsync(int id);
    Task<ServiceResponse<List<Pracownik>>> GetAllEmployeesAsync();
    Task<ServiceResponse<bool>> AddEmployeeAsync(PracownikDTO pracownik);
    Task<ServiceResponse<List<Adres>>> GetAllAddressesAsync();
    Task<ServiceResponse<bool>> AddAddressAsync(AdresDTO adress);
    Task<ServiceResponse<bool>> DeleteAddressAsync(int id);
    Task<ServiceResponse<bool>> DeleteEmployeeAsync(int id);
    Task<ServiceResponse<bool>> UpdateEmployeeAsync(PracownikDTO pracownik);
}