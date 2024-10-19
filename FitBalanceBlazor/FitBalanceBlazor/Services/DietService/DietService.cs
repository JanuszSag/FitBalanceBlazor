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
        return await _context.Diety.ToListAsync();
    }

    /// <summary>
    /// Method <c>GetDietAsync</c> return diet based on id given in parameer
    /// </summary>
    /// <param name="dietId">id of diet stored in database</param>
    /// <returns>diet object</returns>
    public async Task<Dieta?> GetDietAsync(int dietId)
    {
        var result = await _context.Diety.FindAsync(dietId);

        
        return result;
    }
}