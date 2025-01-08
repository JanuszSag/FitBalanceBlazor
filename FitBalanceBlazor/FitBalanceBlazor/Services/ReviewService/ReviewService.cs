using ClassLibrary1;
using FitBalanceBlazor.Context;
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
    public async Task<ServiceResponse<List<Opinia>>> GetAllReviewsAsync()
    {
        var response = new ServiceResponse<List<Opinia>>();
        
        var result = await _context.Opinia.ToListAsync();

        if (result.Count == 0)
        {
            response.Success = false;
            response.Message = "Cannot find reviews";
            return response;
        }
        response.Data = result;
        response.Success = true;
        
        return response;
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