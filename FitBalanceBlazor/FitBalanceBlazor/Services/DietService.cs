using FitBalanceBlazor.Context;
using FitBalanceBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor.Services;

public class DietService(MyDbContext _context)
{
    /// <summary>
    /// Method <c>GetAllDietsAsync</c> returns list of all diets stored in database
    /// </summary>
    /// <returns>List of diets</returns>
    public async Task<List<Dieta>> GetAllDietsAsync()
    {
        return await _context.Diety.ToListAsync();
    }
    
}