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
            .Include(u => u.Wypita_woda)
            .Select(u => new Uzytkownik
            {
                id_uzytkownik = u.id_uzytkownik,
                data_urodzenia = u.data_urodzenia,
                pseudonim = u.pseudonim,
                waga = u.waga,
                wzrost = u.wzrost,
                Wypita_woda = u.Wypita_woda,
                zapotrzebowanie_kaloryczne = u.zapotrzebowanie_kaloryczne,
                Raport = u.Raport,
                email = u.email,
                Opinia = u.Opinia,
                plec = u.plec,
                Pomiar_wagi = u.Pomiar_wagi,
                Pracownik = u.Pracownik,
                Przypisana_dieta = u.Przypisana_dieta
            })
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

    public async Task<ServiceResponse<Uzytkownik>> GetUserDataWithDiet(int userId)
    {

        var response = new ServiceResponse<Uzytkownik>();
        
        var person = await context.Uzytkownik
            .Include(u => u.Przypisana_dieta)
            .Where(user => user.id_uzytkownik==userId)
            .Select(u => new Uzytkownik
        {
            id_uzytkownik = u.id_uzytkownik,
            data_urodzenia = u.data_urodzenia,
            plec = u.plec,
            pseudonim = u.pseudonim,
            waga = u.waga,
            wzrost = u.wzrost,
            email = u.email,
            Przypisana_dieta = u.Przypisana_dieta.Select(d => new Przypisana_dieta
            {
                id_dieta = d.id_dieta,
                id_przypisana_dieta = d.id_przypisana_dieta,
                id_danie = d.id_danie.Select(danie => new Danie
                {
                    id_danie = danie.id_danie,
                    nazwa = danie.nazwa,
                }).ToList()
            }).ToList()
        }).FirstAsync();
            
        
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

    public async Task<ServiceResponse<bool>> AssignDiet(int userId, int dietId)
    {
        var response = new ServiceResponse<bool>();
        try
        {
            var user = await context.Uzytkownik.FindAsync(userId);
            var diet = await context.Dieta.Include(d => d.Danie_id_danie).FirstOrDefaultAsync(d => d.id_dieta == dietId);
            var assignDiets = await context.Przypisana_dieta.ToListAsync();
            
            var meals = diet.Danie_id_danie;
            
            var bufor = user.Przypisana_dieta;
            
            
            /*bufor.Clear();
            bufor = [new Przypisana_dieta()
            {
                id_przypisana_dieta = assignDiets.Count+1,
                id_dieta = dietId,
                id_uzytkownik = userId,
                id_program = 2,
                id_dietaNavigation = diet,
                id_programNavigation = await context.Programy.FindAsync(2 ),
                id_uzytkownikNavigation = user,
                id_danie = meals
            }];
            user.Przypisana_dieta = bufor;*/
            /*var test = new Przypisana_dieta()
            {
                id_dieta = dietId,
                id_uzytkownik = userId,
                id_program = 2,
                id_danie = meals
            };*/

            user.Przypisana_dieta = [];
            user.Przypisana_dieta.Add(new Przypisana_dieta()
            {
                id_dieta = dietId,
                id_danie = meals,
                id_dietaNavigation = diet,
                id_programNavigation = await context.Programy.FindAsync(2),
                id_uzytkownikNavigation = user,
                id_przypisana_dieta = assignDiets.Count+1
            });

            /*
            await context.Przypisana_dieta.AddAsync(test);*/
            
            await context.SaveChangesAsync();
            
            
            response.Data = true;
            response.Success = true;
            return response;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
            return response;
        }
    }
}