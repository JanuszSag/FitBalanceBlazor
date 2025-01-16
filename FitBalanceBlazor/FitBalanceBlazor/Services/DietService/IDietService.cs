using ClassLibrary1;

namespace FitBalanceBlazor.Services.DietService;

public interface IDietService
{
    Task<ServiceResponse<List<Dieta>>> GetAllDietsAsync();
    Task<ServiceResponse<List<Dieta>>> GetAllDietsByIdAsync(List<int> dietId);
    Task<ServiceResponse<List<Dieta>>> GetAllDietsByCategoryIdAsync(int categoryId);
    Task<ServiceResponse<Dieta?>> GetDietAsync(int dietId);
    Task<ServiceResponse<bool>> RemoveDietAsync(int dietId);
    ServiceResponse<bool> AddDiet(DietaDTO diet);
    Task<ServiceResponse<bool>> AddMealsToDiet(int id, List<int> meals);
}
