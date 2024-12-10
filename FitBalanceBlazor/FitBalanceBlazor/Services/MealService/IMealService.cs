namespace FitBalanceBlazor.Services.MealService;

public interface IMealService
{
    Task<List<Danie>> GetAllMealsAsync();
    Task<Danie?> GetMealByIdAsync(int mealId);
}