namespace FitBalanceBlazor.Services.CategoryService;

public interface ICategoryService
{
    Task<List<Rodzaj>> GetCategoriesAsync();
    Task<Rodzaj> GetCategoryByIdAsync(int id);
}