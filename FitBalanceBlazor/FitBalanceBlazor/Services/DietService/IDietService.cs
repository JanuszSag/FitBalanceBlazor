using FitBalanceBlazor.Models;

namespace FitBalanceBlazor.Services.DietService;

public interface IDietService
{
    Task<List<Dieta>> GetAllDietsAsync();
    Task<Dieta?> GetDietAsync(int dietId);
}