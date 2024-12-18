namespace FitBalanceBlazor.Services.ProductService;

public interface IProductService
{
    Task<List<Produkt>> GetProductsAsync();
    Task<Produkt?> GetProductByIdAsync(int id);
    Task<List<Produkt?>> GetProductsForMeal(int id);
}