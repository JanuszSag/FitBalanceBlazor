using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;
using FitBalanceBlazor.Context;

namespace FitBalanceBlazor.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly MyDbContext _context;

    public AuthService(MyDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> LoginAsync(string email, string password)
    {
        var user = await _context.Uzytkownik.FirstOrDefaultAsync(x => x.email.Equals(email));
        if (user == null)
        {
            return false;
        }
        else if (!CheckPassword(password, Encoding.ASCII.GetBytes(user.haslo_hashed), Encoding.ASCII.GetBytes(user.haslo_salt)))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public async Task<bool> RegisterAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public bool CheckPassword(string passwordHash, string passwordSalt)
    {
        throw new NotImplementedException();
    }

    public bool CheckPassword(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var sha256Hash = new HMACSHA512(passwordSalt))
        {
            
        }

        throw new NotImplementedException();
    }
}