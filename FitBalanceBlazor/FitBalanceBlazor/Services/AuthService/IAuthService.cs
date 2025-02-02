using ClassLibrary1;
using Microsoft.AspNetCore.Identity.Data;

namespace FitBalanceBlazor.Services.AuthService;

public interface IAuthService
{
    Task<ServiceResponse<int>> Register(RegisterModel registerModel);
    Task<bool> UserExists(string email);
    Task<ServiceResponse<string>> Login(LoginModel loginModel);

}