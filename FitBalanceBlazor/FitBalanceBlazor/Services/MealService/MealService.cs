using ClassLibrary1;
using FitBalanceBlazor.Context;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor.Services.MealService;

public class MealService : IMealService
{
    private readonly MyDbContext _context;

    public MealService(MyDbContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Method <c>GetAllMealsAsync</c> return list of meals stored in database
    /// </summary>
    /// <returns>list of meals</returns>
    public async Task<ServiceResponse<List<Danie>>> GetAllMealsAsync()
    {
        var response = new ServiceResponse<List<Danie>>();
        var meals = await _context.Danie.ToListAsync();

        if (meals is null)
        {
            response.Success = false;
            response.Message = "Cannot get all meals.";
            return response;
        }
        response.Data = meals;
        response.Success = true;
        return response;
    }

    /// <summary>
    /// Method <c>GetMealByIdAsync</c> return meal object stored in database
    /// </summary>
    /// <param name="mealId">id of meal</param>
    /// <returns>meal object</returns>
    public async Task<Danie?> GetMealByIdAsync(int mealId)
    {
        return await _context.Danie.FindAsync(mealId);
    }

    public async Task<ServiceResponse<Przypisana_dieta>> GetMealsByUserIdAsync(int userId)
    {
        var response = new ServiceResponse<Przypisana_dieta>();

        var przypisanie = await _context.Przypisana_dieta
            .Select(d => new Przypisana_dieta
            {
                id_danie = d.id_danie,
                id_uzytkownik = d.id_uzytkownik,
                id_program = d.id_program,
                id_dieta = d.id_dieta,
                id_przypisana_dieta = d.id_przypisana_dieta,
                id_dietaNavigation = d.id_dietaNavigation,
                id_programNavigation = d.id_programNavigation,
                id_uzytkownikNavigation = d.id_uzytkownikNavigation
                
            })
            .Where(d => d.id_uzytkownik == userId)
            .FirstOrDefaultAsync();
        if (przypisanie is null)
        {
            response.Success = false;
            response.Message = "Cannot find diet";
        }
        response.Data = przypisanie;
        response.Success = true;
        return response;
    }
}