namespace FitBalanceBlazor.Services.AuthService;

public class AuthService : IAuthService
{
    public async Task<bool> LoginAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RegisterAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public string decryptPass(string passwordHash, string passwordSalt)
    {
        throw new NotImplementedException();
    }
}