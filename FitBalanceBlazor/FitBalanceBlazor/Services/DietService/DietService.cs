using FitBalanceBlazor.Context;
using FitBalanceBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor.Services.DietService;

public class DietService: IDietService
{
    private readonly MyDbContext _context;

    public DietService(MyDbContext context)
    {
        this._context = context;
    }
    /// <summary>
    /// Method <c>GetAllDietsAsync</c> return list of all diets stored in database
    /// </summary>
    /// <returns>List of diets</returns>
    public async Task<List<Dieta>> GetAllDietsAsync()
    {
        return await _context.Dieta.ToListAsync();
    }
    
    /// <summary>
    /// Method <c>GetAllDietsByCategoryIdAsync</c> return list of all diets with specific category stored in database
    /// </summary>
    /// <param name="categoryId">Id of category</param>
    /// <returns>List of diets with specific category</returns>
    public async Task<List<Dieta>> GetAllDietsByCategoryIdAsync(int categoryId)
    {
        return await _context.Dieta.Where(d => d.rodzaj == categoryId).ToListAsync();
    }
    
    
    /// <summary>
    /// Method <c>GetDietAsync</c> return diet based on id given in parameter
    /// </summary>
    /// <param name="dietId">id of diet stored in database</param>
    /// <returns>diet object</returns>
    public async Task<Dieta?> GetDietAsync(int dietId)
    {
        var result = await _context.Dieta.FindAsync(dietId);

        
        return result;
    }

    /// <summary>
    /// method <c>RemoveDietAsync</c> removes diet from database based on id parameter
    /// </summary>
    /// <param name="dietId">id of diet to remove</param>
    public void RemoveDietAsync(int dietId)
    {
        var ItemToRemove = _context.Dieta.Find(dietId);
        
        _context.Dieta.Remove(ItemToRemove);
    }
}