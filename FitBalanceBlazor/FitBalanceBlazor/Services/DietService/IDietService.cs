using ClassLibrary1;

namespace FitBalanceBlazor.Services.DietService;

public interface IDietService
{
    Task<List<Dieta>> GetAllDietsAsync();
    Task<List<Dieta>> GetAllDietsByCategoryIdAsync(int categoryId);
    Task<Dieta?> GetDietAsync(int dietId);
    void RemoveDietAsync(int dietId);
    void AddDiet(DietaDTO diet);
}
