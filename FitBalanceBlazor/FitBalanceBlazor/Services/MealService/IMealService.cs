using ClassLibrary1;

namespace FitBalanceBlazor.Services.MealService;

public interface IMealService
{
    Task<ServiceResponse<List<Danie>>> GetAllMealsAsync();
    Task<Danie?> GetMealByIdAsync(int mealId);
}