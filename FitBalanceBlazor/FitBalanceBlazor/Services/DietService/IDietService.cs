using ClassLibrary1;
using FitBalanceBlazor.Models;

namespace FitBalanceBlazor.Services.DietService;

public interface IDietService
{
    Task<List<Dieta>> GetAllDietsAsync();
    Task<List<Dieta>> GetAllDietsByCategoryIdAsync(int categoryId);
    Task<Dieta?> GetDietAsync(int dietId);
    void RemoveDietAsync(int dietId);
    void AddDietAsync(DietaDTO diet);
}
