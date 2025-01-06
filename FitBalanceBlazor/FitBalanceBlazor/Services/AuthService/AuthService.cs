using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ClassLibrary1;
using FitBalanceBlazor.Context;
using Microsoft.IdentityModel.Tokens;

namespace FitBalanceBlazor.Services.AuthService;

public class AuthService(MyDbContext context, IConfiguration configuration)
    : IAuthService
{

    public async Task<bool> UserExists(string email)
    {
        var entity = await context.Uzytkownik.FirstOrDefaultAsync();
        return entity is null;
    }

    public async Task<ServiceResponse<string>> Login(LoginModel loginModel)
    {
        var response = new ServiceResponse<string>();
        var account = context.Uzytkownik.FirstOrDefaultAsync(x => x.email == loginModel.Email).Result;
        
        if (account is null)
        {
            response.Success = false;
            response.Message = "User not found";
        }
        else if (!CheckPassword(loginModel.Password,account.haslo_hashed, account.haslo_salt))
        {
            response.Success = false;
            response.Message = "Wrong password";
        }
        else
        {
            response.Data = CreateToken(account);
        }
        response.Success = true;
        response.Message = "Login successful";
        return response;
    }

    public async Task<ServiceResponse<int>> Register(RegisterModel registerModel)
    {
        var response = new ServiceResponse<int>();
        var findAccount = await context.Uzytkownik.FirstOrDefaultAsync(x => x.email.ToLower().Equals(registerModel.Email.ToLower()));

        
        if (findAccount is not null)
        {
            response.Success = false;
            response.Message = "User already exists";

            return response;
        }
        
        CreatePasswordHash(registerModel.Password, out byte[] passwordHash, out byte[] passwordSalt);

        var user = new Uzytkownik
        {
            id_uzytkownik = context.Uzytkownik.Count()+1,
            email = registerModel.Email,
            haslo_hashed = passwordHash,
            haslo_salt = passwordSalt,
            wzrost = registerModel.Height,
            waga = registerModel.Weight,
            plec = registerModel.Gender,
            pseudonim = registerModel.Username,
            data_urodzenia = DateOnly.FromDateTime((DateTime)registerModel.Birthday)
        };

        context.Uzytkownik.Add(user);
        await context.SaveChangesAsync();
        
        response.Data = user.id_uzytkownik;
        response.Message = "User created";
        
        return response;
    }
    

    private bool CheckPassword(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA256(passwordSalt))
        {
            byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for(int i = 0; i < passwordHash.Length; i++)
                if (computedHash[i] != passwordHash[i])
                    return false;
        }

        return true;
    }
    private string CreateToken(Uzytkownik user)
    {
        List<Claim> claims =
        [
            new Claim(ClaimTypes.NameIdentifier, user.id_uzytkownik.ToString()),
            new Claim(ClaimTypes.Name, user.email),
            new Claim(ClaimTypes.Role,
                context.Pracownik.Any(p => p.id_uzytkownik == user.id_uzytkownik) ? "Employee" : "User")
        ];

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA256();
        passwordSalt = hmac.Key;
        var passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
        passwordHash = hmac.ComputeHash(passwordBytes);
    }
    
}