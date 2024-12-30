using ClassLibrary1;
using FitBalanceBlazor.Context;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor.Services.UserService;

public class UserService(MyDbContext context) : IUserService
{
    private readonly MyDbContext _context = context;


    public async Task<ServiceResponse<Uzytkownik>> GetAllUserData(int userId)
    {
        var response = new ServiceResponse<Uzytkownik>();

        var person = await context.Uzytkownik.FindAsync(userId);

        if (person == null)
        {
            response.Success = false;
            response.Message = "Cannot find user";
        }
        else
        {
            person.haslo_hashed = null;
            person.haslo_salt = null;
            
            context.ChangeTracker.Clear();  
            //context.ChangeTracker.Entries<Uzytkownik>().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);
            
            response.Data = person;
            response.Success = true;
        }
        return response;
    }

    public async Task<ServiceResponse<bool>> UpdateUserData(int userId, Uzytkownik uzytkownik)
    {
        var response = new ServiceResponse<bool>();
        
        var person = await context.Uzytkownik.FindAsync(userId);

        if (person == null)
        {
            response.Success = false;
            response.Message = "Cannot find user";
        }
        else
        {
            person.data_urodzenia = uzytkownik.data_urodzenia;
            person.plec = uzytkownik.plec;
            person.pseudonim = uzytkownik.pseudonim;
            person.waga = uzytkownik.waga;
            person.wzrost = uzytkownik.wzrost;
            
            response.Data = true;
            response.Success = true;
            
            await context.SaveChangesAsync();
        }
        return response;
    }
}