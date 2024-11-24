using FitBalanceBlazor.Context;
using FitBalanceBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor.Services.ReviewService;

public class ReviewService : IReviewService
{
    private readonly MyDbContext _context;

    public ReviewService(MyDbContext context)
    {
        this._context = context;
    }
    /// <summary>
    /// Method <c>GetAllDietsAsync</c> return list of all reviews stored in database
    /// </summary>
    /// <returns>List of reviews</returns>
    public async Task<List<Opinia>> GetAllReviewsAsync()
    {
        return await _context.Opinia.ToListAsync();
    }
    
    /// <summary>
    /// Method <c>GetReviewByIdAsync</c> return review based on id given in parameter
    /// </summary>
    /// <param name="id">id of review stored in database</param>
    /// <returns>review object</returns>
    public async Task<Opinia> GetReviewByIdAsync(int id)
    {
        return await _context.Opinia.FindAsync(id);
    }
}