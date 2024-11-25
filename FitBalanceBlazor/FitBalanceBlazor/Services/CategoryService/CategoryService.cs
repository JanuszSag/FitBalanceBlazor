using FitBalanceBlazor.Context;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly MyDbContext _context;

    public CategoryService(MyDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Method <c>GetCategoriesAsync</c> return list of all diet categories stored in database
    /// </summary>
    /// <returns>List of categories</returns>
    public async Task<List<Rodzaj>> GetCategoriesAsync()
    {
        return await _context.Rodzaj.ToListAsync();
    }

    /// <summary>
    /// Method <c>GetCategoryByIdAsync</c> return category object based on given id stored in database
    /// </summary>
    /// <param name="id">Id of category</param>
    /// <returns>Object of category</returns>
    public async Task<Rodzaj> GetCategoryByIdAsync(int id)
    {
        return await _context.Rodzaj.FindAsync(id);
    }
}