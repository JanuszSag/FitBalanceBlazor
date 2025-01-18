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

        var person = await context.Uzytkownik
            .Include(u => u.Przypisana_dieta)
            .FirstAsync(u => u.id_uzytkownik==userId);

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

    public async Task<ServiceResponse<bool>> UpdateUserData(Uzytkownik uzytkownik)
    {
        var response = new ServiceResponse<bool>();
        
        var person = await context.Uzytkownik.FindAsync(uzytkownik.id_uzytkownik);

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
            person.email = uzytkownik.email;
            
            response.Data = true;
            response.Success = true;
            
            await context.SaveChangesAsync();
        }
        return response;
    }

    public async Task<ServiceResponse<List<Uzytkownik>>> SearchListUserData()
    {
        var response = new ServiceResponse<List<Uzytkownik>>();
        
        var person = await context.Uzytkownik.ToListAsync();
        if (person is null)
        {
            response.Success = false;
            response.Message = $"Cannot find users";
            return response;
        }
        response.Data = person;
        
        response.Success = true;
        response.Message = "Success";
        
        return response;
    }

}