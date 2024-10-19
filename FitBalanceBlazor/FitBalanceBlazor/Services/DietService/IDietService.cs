using FitBalanceBlazor.Models;

namespace FitBalanceBlazor.Services;

public interface IDietService
{
    Task<List<Dieta>> GetAllDietsAsync();
    Task<Dieta?> GetDietAsync(int dietId);
}