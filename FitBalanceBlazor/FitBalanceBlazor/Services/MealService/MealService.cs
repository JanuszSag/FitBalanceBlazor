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
    public async Task<List<Danie>> GetAllMealsAsync()
    {
        return await _context.Danie.ToListAsync();
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
}