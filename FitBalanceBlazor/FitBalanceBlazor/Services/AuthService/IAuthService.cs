namespace FitBalanceBlazor.Services.AuthService;

public interface IAuthService
{
    Task<bool> LoginAsync(string username, string password);
    Task<bool> RegisterAsync(string username, string password);
    bool CheckPassword(string passwordHash, string passwordSalt);
}